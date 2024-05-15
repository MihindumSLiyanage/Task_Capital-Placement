using Task.Models;

namespace Task.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(string id);
        Task<Employee> GetEmployeeByIdAsync(string id);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
    }
}
