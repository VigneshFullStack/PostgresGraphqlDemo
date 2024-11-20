using PostgresGraphqlDemo.API.Models;

namespace PostgresGraphqlDemo.API.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<IEnumerable<Employee>> GetEmployeeByIdAsync(int id);
        Task<Employee> CreateEmployeeAsync(EmployeeInput employee);
        Task<Employee> UpdateEmployeeAsync(int id, EmployeeInput employee);
        Task<bool> DeleteEmployeeAsync(int id);
        void LogError(Exception ex, string message);
    }
}
