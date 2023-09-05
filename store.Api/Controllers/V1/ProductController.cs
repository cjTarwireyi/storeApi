using Microsoft.AspNetCore.Mvc;
using store.Api.Contracts;
using store.Api.Contracts.V1.Requests;
using store.Api.Contracts.V1.Responses;
using store.DataLayer.Model;
using store.DataLayer.Services;

namespace store.Api.Controllers.V1
{
    [Route(ApiRoutes.Products.GetAll)]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <returns>All Products</returns>
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await _service.GetProducts());
        }

        /// <summary>
        /// Gets a specific Product.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Single Product</returns>
        [HttpGet("{productId}", Name = "GetProduct")]
        public async Task<ActionResult> GetProduct( string productId)
        {
            var product = await _service.GetProduct(productId);
            if(product == null)
            {
                return NotFound();
            }

            var response = new GetProductResponse
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
            };

            return Ok(response);
        }
        /// <summary>
        /// Creates a specific Product.
        /// </summary>       
        /// <param name="productRequest"></param>
        /// <returns>Created product</returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProductRequest productRequest)
        {
            var product = new Product
            {
                Name = productRequest.Name,
                Description = productRequest.Description,
                Price = productRequest.Price,
                Quantity = productRequest.Quantity,
                Id = Guid.NewGuid()
            };

            await _service.AddProduct(product);

            var response = new CreateProductResponse { Id = product.Id.ToString() };

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Products.Get.Replace("{productId}", response.Id);
            return Created(locationUri, response);
        }
        /// <summary>
        /// Updates a specific Product.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productRequest"></param>
        /// <returns>updated product</returns>
        [HttpPut]
        public async Task<ActionResult> Update(string productId, [FromBody] UpdateProductRequest productRequest)
        {
            var product = new Product
            {
                Name = productRequest.Name,
                Description = productRequest.Description,
                Price = productRequest.Price,
                Quantity = productRequest.Quantity,
                Id = new Guid(productId)
            };

            var updated =  await _service.UpdateProduct(product);

            if (updated)
            {
                return Ok(product);
            }
            return NotFound();
        }

        /// <summary>
        /// Deletes a specific Product.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>return no content</returns>
        [HttpDelete]
        public ActionResult Delete(string productId)
        {
            _service.DeleteProduct(productId.ToString());
            return NoContent();
        }

    }
}
