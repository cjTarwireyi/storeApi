using Microsoft.AspNetCore.Mvc;
using store.DataLayer.Services;

namespace store.Api.Controllers.V1
{
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }
    }
}
