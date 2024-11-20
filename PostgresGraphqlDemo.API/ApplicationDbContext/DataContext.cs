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

            // configure employee table
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Age)
                    .IsRequired();

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Salary)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("NOW()");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedAt)
                    .HasDefaultValueSql("NOW()");

                // Adding check constraints at the entity level
                entity.HasCheckConstraint("CK_Age", "Age > 18");
                entity.HasCheckConstraint("CK_Gender", "Gender IN ('Male', 'Female', 'Other')");
            });

            modelBuilder.Entity<QueryResult>().HasNoKey();
            modelBuilder.Entity<ExecuteResult>().HasNoKey();
        }
    }
}
