using Microsoft.EntityFrameworkCore;
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

        public async Task<Employee?> GetEmployee(string id)
        {
            var employee = await _db.Employees.FindAsync(id);

            if (employee == null)
                throw new Exception("Employee awas not found");

            return employee;
           
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _db.Employees.ToListAsync();
        }

        public Task<bool> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
