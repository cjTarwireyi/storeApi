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
        public Task<bool> AddEmployee(Employee customer)
        {
            throw new NotImplementedException();
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

        public Task<bool> UpdateEmployee(Employee customer)
        {
            throw new NotImplementedException();
        }
    }
}
