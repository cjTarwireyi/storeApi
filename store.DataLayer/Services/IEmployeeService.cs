using store.DataLayer.Model;

namespace store.DataLayer.Services
{
    internal interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee?> GetEmployee(string id);
        Task<bool> AddEmployee(Employee customer);
        Task<bool> UpdateEmployee(Employee customer);
        Task<bool> DeleteEmployee(string id);
    }
}
