using store.DataLayer.Model;

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
