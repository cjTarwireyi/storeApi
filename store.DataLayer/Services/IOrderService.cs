using store.DataLayer.Model;

namespace store.DataLayer.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();
        Task<Order?> GetOrder(string id);
        Task<bool> AddOrder(Order Order);
        Task<bool> UpdateOrder(Order Order);
        Task<bool> DeleteOrder(string id);
    }
}
