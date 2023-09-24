using Microsoft.EntityFrameworkCore;
using store.Api.Data;
using store.DataLayer.Model;

namespace store.DataLayer.Services
{
    internal class OrderService : IOrderService
    {
        private readonly StoreDBContext _db;

        public OrderService(StoreDBContext db)
        {
            _db = db;
        }

        public async Task<bool> AddOrder(Order order)
        {
            _db.Orders.Add(order);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteOrder(string id)
        {
            var orderToRemopve = await GetOrder(id);

            _db.Orders.Remove(orderToRemopve);

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<Order?> GetOrder(string id)
        {
            var order= await _db.Orders.FindAsync(id);

            if (order== null)
                throw new Exception("Order awas not found");

            return order;
        }

        public async Task<List<Order>> GetOrders()
        {
          return await _db.Orders.ToListAsync();
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            await GetOrder(order.Id.ToString());
            _db.Orders.Update(order);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
