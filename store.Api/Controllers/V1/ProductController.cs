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
        [HttpGet]
        public ActionResult GetProducts()
        {
            return Ok(_service.GetProducts());
        }

        [HttpGet("{productId}", Name = "GetProduct")]
        public ActionResult GetProduct( string productId)
        {
            var product = _service.GetProduct(productId);
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

        [HttpPost]
        public ActionResult Create([FromBody] CreateProductRequest productRequest)
        {
            var product = new Product
            {
                Name = productRequest.Name,
                Description = productRequest.Description,
                Price = productRequest.Price,
                Quantity = productRequest.Quantity,
                Id = Guid.NewGuid().ToString()
            };

            _service.AddProduct(product);

            var response = new CreateProductResponse { Id = product.Id };

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Products.Get.Replace("{productId}", response.Id);
            return Created(locationUri, response);
        }

        [HttpPut]
        public ActionResult Update([FromRoute] Guid postId, [FromBody] UpdateProductRequest productRequest)
        {
            var product = new Product
            {
                Name = productRequest.Name,
                Description = productRequest.Description,
                Price = productRequest.Price,
                Quantity = productRequest.Quantity,
                Id = postId.ToString()
            };

            var updated =   _service.UpdateProduct(product);

            if (updated)
            {
                return Ok(product);
            }
            return NotFound();
        }


    }
}
