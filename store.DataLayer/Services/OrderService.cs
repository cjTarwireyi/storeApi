using store.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DataLayer.Services
{
    internal class OrderService : IOrderService
    {
        public Task<bool> AddOrder(Order Order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrder(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetOrder(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrder(Order Order)
        {
            throw new NotImplementedException();
        }
    }
}
