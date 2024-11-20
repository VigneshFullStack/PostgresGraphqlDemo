using HotChocolate.Subscriptions;
using PostgresGraphqlDemo.API.Models;
using PostgresGraphqlDemo.API.Repository;

namespace PostgresGraphqlDemo.API.Resolvers
{
    public class Mutation(
            IEmployeeRepository employeeRepository
            , ILogger<Mutation> logger
        )
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly ILogger<Mutation> _logger = logger;

        public Task<Employee> CreateEmployeeAsync(EmployeeInput input)
            => ExecuteWithLoggingAsync(async () =>
            {
                var employee = await _employeeRepository.CreateEmployeeAsync(input);
                return employee;
            }, "Error creating Employee");

        public Task<Employee> UpdateEmployeeAsync(int id, EmployeeInput input)
            => ExecuteWithLoggingAsync(async () =>
            {
                var employee = await _employeeRepository.UpdateEmployeeAsync(id, input);
                return employee;
            }, "Error updating Employee");

        public Task<bool> DeleteEmployeeAsync(int id)
            => ExecuteWithLoggingAsync(async () =>
            {
                var success = await _employeeRepository.DeleteEmployeeAsync(id);
                return success;
            }, "Error deleting Employee");

        private async Task<T> ExecuteWithLoggingAsync<T>(Func<Task<T>> action, string errorMessage)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                _employeeRepository.LogError(ex, errorMessage);
                throw;
            }
        }
    }
}
