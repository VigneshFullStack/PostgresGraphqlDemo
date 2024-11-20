using Microsoft.EntityFrameworkCore;
using PostgresGraphqlDemo.API.Models;

namespace PostgresGraphqlDemo.API.ApplicationDbContext
{
    public interface IDataContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<QueryResult>? QueryResult { get; set; }
        public DbSet<ExecuteResult>? ExecuteResult { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
