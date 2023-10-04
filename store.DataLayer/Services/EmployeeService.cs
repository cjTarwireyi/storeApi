using store.Api.Data;
using store.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DataLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly StoreDBContext _db;
        public EmployeeService(StoreDBContext context)
        {
            _db = context;
        }
        public async Task<bool> AddEmployee(Employee employee)
        {
            _db.Employees.Add(employee);
            return await _db.SaveChangesAsync() > 0;
        }

        public Task<bool> DeleteEmployee(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee?> GetEmployee(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
