using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store.DataLayer.Services;

namespace store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetProducts()
        {
            ProductService productService = new ProductService();
            return Ok(productService.GetProducts());
        }
    }
}
