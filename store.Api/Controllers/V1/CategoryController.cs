using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store.Api.Contracts.V1.Requests;
using store.Api.Contracts.V1.Responses;
using store.Api.Contracts;
using store.DataLayer.Model;
using store.DataLayer.Services;

namespace store.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;


        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        /// <summary>
        /// Gets all Categories.
        /// </summary>
        /// <returns>All Categories</returns>
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            return Ok(await _service.GetCategories());
        }

        /// <summary>
        /// Gets a specific Category.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>Single Category</returns>
        [HttpGet("{CategoryId}", Name = "GetCategory")]
        public async Task<ActionResult> GetCategory(string categoryId)
        {
            var category = await _service.GetCategory(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            var response = new GetCategoryResponse
            {
                Name = category.Name,
                Description = category.Description,
                LastModifiedDate = category.LastModifiedDate,
                LastModifiedUser = category.LastModifiedUser,
            };

            return Ok(response);
        }
        /// <summary>
        /// Creates a specific Category.
        /// </summary>       
        /// <param name="categoryRequest"></param>
        /// <returns>Created Category</returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategoryRequest categoryRequest)
        {
            var category = new Category
            {
                Name = categoryRequest.Name,
                Description = categoryRequest.Description,
                Id = Guid.NewGuid()
            };

            await _service.AddCategory(category);

            var response = new CreateCategoryResponse { Id = category.Id.ToString() };

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Category.Get.Replace("{categoryId}", response.Id);
            return Created(locationUri, response);
        }
        /// <summary>
        /// Updates a specific Category.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="categoryRequest"></param>
        /// <returns>updated Category</returns>
        [HttpPut]
        public async Task<ActionResult> Update(string categoryId, [FromBody] UpdateCategoryRequest categoryRequest)
        {
            var category = new Category
            {
                Name = categoryRequest.Name,
                Description = categoryRequest.Description,
                Id = new Guid(categoryId)
            };

            var updated = await _service.UpdateCategory(category);

            if (updated)
            {
                return Ok(category);
            }
            return NotFound();
        }

        /// <summary>
        /// Deletes a specific Category.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>return no content</returns>
        [HttpDelete]
        public ActionResult Delete(string categoryId)
        {
            _service.DeleteCategory(categoryId.ToString());
            return NoContent();
        }
    }
}
