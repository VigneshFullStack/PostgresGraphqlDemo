using Microsoft.EntityFrameworkCore;
using PostgresGraphqlDemo.API.Models;

namespace PostgresGraphqlDemo.API.ApplicationDbContext
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options), IDataContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<QueryResult>? QueryResult { get; set; }
        public DbSet<ExecuteResult>? ExecuteResult { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .ToTable("employees");

            modelBuilder.Entity<QueryResult>().HasNoKey();
            modelBuilder.Entity<ExecuteResult>().HasNoKey();
        }
    }
}
