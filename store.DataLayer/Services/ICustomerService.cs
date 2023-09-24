using store.DataLayer.Model;

namespace store.DataLayer.Services
{
    internal interface ICustomerService
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer?> GetCustomer(string id);
        Task<bool> AddCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomer(string id);
    }
}
