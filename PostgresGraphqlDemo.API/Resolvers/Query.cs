using PostgresGraphqlDemo.API.Models;
using PostgresGraphqlDemo.API.Repository;

namespace PostgresGraphqlDemo.API.Resolvers
{
    public class Query(
            IEmployeeRepository employeeRepository
            , IHttpContextAccessor httpContextAccessor
            , IConfiguration configuration
        )
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IConfiguration _configuration = configuration;

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await ExecuteWithLoggingAsync<Employee>(
                () => _employeeRepository.GetEmployeesAsync(),
                "Error getting Employees"
            );
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByIdAsync(int id)
        {
            return await ExecuteWithLoggingAsync<Employee>(
                () => _employeeRepository.GetEmployeeByIdAsync(id),
                "Error getting Employee"
            );
        }

        private async Task<IEnumerable<T>> ExecuteWithLoggingAsync<T>(Func<Task<IEnumerable<T>>> action, string errorMessage)
        {
            try
            {
                var result = await action();
                return result ?? Enumerable.Empty<T>();
            }
            catch (Exception ex)
            {
                _employeeRepository.LogError(ex, errorMessage);
                throw;
            }
        }
    }
}
