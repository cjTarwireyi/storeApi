using Microsoft.AspNetCore.Mvc;
using store.Api.Contracts.V1.Requests;
using store.Api.Contracts.V1.Responses;
using store.Api.Contracts;
using store.DataLayer.Services;
using static store.Api.Contracts.ApiRoutes;
using store.DataLayer.Model;

namespace store.Api.Controllers.V1
{
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }
        /// <summary>
        /// Gets all Customers.
        /// </summary>
        /// <returns>All Customers</returns>
        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            return Ok(await _service.GetCustomers());
        }

        /// <summary>
        /// Gets a specific Customer.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>Single Customer</returns>
        [HttpGet("{CustomerId}", Name = "GetCustomer")]
        public async Task<ActionResult> GetCustomer(string customerId)
        {
            var customer = await _service.GetCustomer(customerId);
            if (customer == null)
            {
                return NotFound();
            }

            var response = new GetCustomerResponse
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Address = customer.Address,
                Phone= customer.Phone,
                LastModifiedUser= customer.LastModifiedUser,
            };

            return Ok(response);
        }
        /// <summary>
        /// Creates a specific Customer.
        /// </summary>       
        /// <param name="customerRequest"></param>
        /// <returns>Created Customer</returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCustomerRequest customerRequest)
        {
            var customer = new Customer
            {
                FirstName = customerRequest.FirstName,
                LastName = customerRequest.LastName,
                Email = customerRequest.Email,
                Address = customerRequest.Address,
                Phone = customerRequest.Phone,
                LastModifiedUser = customerRequest.LastModifiedUser,
                Id = Guid.NewGuid()
            };

            await _service.AddCustomer(customer);

            var response = new CreateCustomerResponse { Id = customer.Id.ToString() };

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.CustomerRoutes.Get.Replace("{customerId}", response.Id);
            return Created(locationUri, response);
        }
        /// <summary>
        /// Updates a specific Customer.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="customerRequest"></param>
        /// <returns>updated Customer</returns>
        [HttpPut]
        public async Task<ActionResult> Update(string customerId, [FromBody] UpdateCustomerRequest customerRequest)
        {
            var customer = new Customer
            {
                FirstName = customerRequest.FirstName,
                LastName = customerRequest.LastName,
                Email = customerRequest.Email,
                Address = customerRequest.Address,
                Phone = customerRequest.Phone,
                Id = new Guid(customerId)
            };

            var updated = await _service.UpdateCustomer(customer);

            if (updated)
            {
                return Ok(customer);
            }
            return NotFound();
        }

        /// <summary>
        /// Deletes a specific Customer.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>return no content</returns>
        [HttpDelete]
        public ActionResult Delete(string customerId)
        {
            _service.DeleteCustomer(customerId.ToString());
            return NoContent();
        }
    }
}
