using store.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DataLayer.Services
{
    internal interface IOrderService
    {
        Task<List<Order>> GetOrders();
        Task<Order?> GetOrder(string id);
        Task<bool> AddOrder(Order Order);
        Task<bool> UpdateOrder(Order Order);
        Task<bool> DeleteOrder(string id);
    }
}
