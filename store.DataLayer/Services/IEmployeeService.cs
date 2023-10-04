using store.DataLayer.Model;

namespace store.DataLayer.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee?> GetEmployee(string id);
        Task<bool> AddEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(string id);
    }
}
