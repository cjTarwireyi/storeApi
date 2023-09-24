using Microsoft.EntityFrameworkCore;
using store.Api.Data;
using store.DataLayer.Model;

namespace store.DataLayer.Services
{
    internal class CustomerService : ICustomerService
    {
        private readonly StoreDBContext _db;

        public CustomerService(StoreDBContext db)
        {
            _db = db;
        }

        public async Task<bool> AddCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCustomer(string id)
        {
            var customerToRemove = await GetCustomer(id);

            _db.Customers.Remove(customerToRemove);

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomer(string id)
        {
            var customer = await _db.Customers.FindAsync(id);

            if (customer == null)
                throw new Exception("Costomer awas not found");

            return customer;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            await GetCustomer(customer.Id.ToString());
            _db.Customers.Update(customer);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
