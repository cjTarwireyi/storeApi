using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store.Api.Contracts;
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
    }
}
