using Microsoft.EntityFrameworkCore;
using PostgresGraphqlDemo.API.ApplicationDbContext;
using PostgresGraphqlDemo.API.BusinessService;
using PostgresGraphqlDemo.API.Models;
using System.Security.Claims;

namespace PostgresGraphqlDemo.API.Repository
{
    public class EmployeeRepository(
            IDbContextFactory<DataContext> contextFactory
            , ILogger<EmployeeRepository> logger
            , IHttpContextAccessor httpContextAccessor
            , IAuditService auditService
            , IConfiguration configuration
        ) : IEmployeeRepository
    {
        private readonly IDbContextFactory<DataContext> _contextFactory = contextFactory;
        private readonly ILogger<EmployeeRepository> _logger = logger;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly IAuditService _auditService = auditService;
        private readonly IConfiguration _configuration = configuration;

        private string GetUserName()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user != null)
            {
                var nameClaim = user.FindFirst(ClaimTypes.Name) ?? user.FindFirst("name");
                return nameClaim?.Value ?? "Unknown";
            }

            return "Unknown";
        }

        private async Task<T> ExecuteWithLoggingAsync<T>(
            Func<DataContext, Task<T>> operation,
            string errorMessage)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            try
            {
                return await operation(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, errorMessage);
                throw;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await ExecuteWithLoggingAsync(
                async context => await context.Employees.ToListAsync(),
                "Error retrieving Employees"
            );
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByIdAsync(int id)
        {
            var employee = await ExecuteWithLoggingAsync(
                async context => await context.Employees.FirstOrDefaultAsync(e => e.Id == id),
                "Error retrieving Employee by Id"
            );

            // Return a list containing the single employee, or an empty list if not found
            return employee != null ? new List<Employee> { employee } : Enumerable.Empty<Employee>();
        }

        public async Task<Employee> CreateEmployeeAsync(EmployeeInput input)
        {
            return await ExecuteWithLoggingAsync(
                async context =>
                {
                    var employee = new Employee
                    {
                        Name = input.Name,
                        Age = input.Age,
                        Gender = input.Gender,
                        Salary = input.Salary
                    };

                    _auditService.SetCreationAudit(employee, GetUserName());
                    context.Employees.Add(employee);
                    await context.SaveChangesAsync();
                    return employee;
                },
                $"Error creating Employee"
            );
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, EmployeeInput input)
        {
            return await ExecuteWithLoggingAsync(
                async context =>
                {
                    var employee = await context.Employees.FindAsync(id) ?? throw new Exception("Invalid Employee input");

                    employee.Name = input.Name;
                    employee.Age = input.Age;
                    employee.Salary = input.Salary;
                    employee.Gender = input.Gender;

                    _auditService.SetModificationAudit(employee, GetUserName());
                    await context.SaveChangesAsync();
                    return employee;
                },
                $"Error updating Employee"
            );
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            return await ExecuteWithLoggingAsync(
                async context =>
                {
                    var employee = await context.Employees.FindAsync(id);
                    if (employee == null) return false;

                    context.Employees.Remove(employee);
                    await context.SaveChangesAsync();
                    return true;
                },
                $"Error deleting Employee"
            );
        }

        public void LogError(Exception ex, string message)
        {
            _logger.LogError(ex, message);
        }
    }
}
