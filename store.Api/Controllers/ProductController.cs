using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store.DataLayer.Services;

namespace store.Api.Controllers
{
    [Route("api/[controller]")]
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
