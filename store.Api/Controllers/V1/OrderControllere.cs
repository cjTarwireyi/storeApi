using Microsoft.AspNetCore.Mvc;
using store.Api.Contracts.V1.Requests;
using store.Api.Contracts.V1.Responses;
using store.Api.Contracts;
using store.DataLayer.Services;
using store.DataLayer.Model;

namespace store.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderControllere : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderControllere(IOrderService service)
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
            return Ok(await _service.GetOrders());
        }

        /// <summary>
        /// Gets a specific Order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>Single Order</returns>
        [HttpGet("{OrderId}", Name = "GetOrder")]
        public async Task<ActionResult> GetOrder(string orderId)
        {
            var order = await _service.GetOrder(orderId);
            if (order == null)
            {
                return NotFound();
            }

            var response = new GetOrderResponse
            {
                CustomerId = order.CustomerId,
                OrderNumber = order.OrderNumber,
                Quantity = order.Quantity,
                Price = order.Price,
                OrderDate = order.OrderDate,
                ShippingAddress = order.ShippingAddress,
                ProductId = order.ProductId,
                Id= order.Id,
            };

            return Ok(response);
        }
        /// <summary>
        /// Creates a specific Order.
        /// </summary>       
        /// <param name="orderRequest"></param>
        /// <returns>Created Order</returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrderRequest orderRequest)
        {
            var order = new Order
            {
                CustomerId = orderRequest.CustomerId,
                OrderNumber = orderRequest.OrderNumber,
                Quantity = orderRequest.Quantity,
                Price = orderRequest.Price,
                OrderDate = orderRequest.OrderDate,
                ShippingAddress = orderRequest.ShippingAddress,
                ProductId = orderRequest.ProductId,
                Id = Guid.NewGuid()
            };

            await _service.AddOrder(order);

            var response = new CreateOrderResponse { Id = order.Id};

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Order.Get.Replace("{orderId}", response.Id.ToString());
            return Created(locationUri, response);
        }
        /// <summary>
        /// Updates a specific Order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderRequest"></param>
        /// <returns>updated Order</returns>
        [HttpPut]
        public async Task<ActionResult> Update(string orderId, [FromBody] UpdateOrderRequest orderRequest)
        {
            var order = new Order
            {
                Id = new Guid(orderId),
                CustomerId = orderRequest.CustomerId,
                OrderNumber = orderRequest.OrderNumber,
                Quantity = orderRequest.Quantity,
                Price = orderRequest.Price,
                OrderDate = orderRequest.OrderDate,
                ShippingAddress = orderRequest.ShippingAddress,
                ProductId = orderRequest.ProductId,
            };

            var updated = await _service.UpdateOrder(order);

            if (updated)
            {
                return Ok(order);
            }
            return NotFound();
        }

        /// <summary>
        /// Deletes a specific Order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>return no content</returns>
        [HttpDelete]
        public ActionResult Delete(string orderId)
        {
            _service.DeleteOrder(orderId.ToString());
            return NoContent();
        }
    }
}
