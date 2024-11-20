using Microsoft.EntityFrameworkCore;
using Serilog;

namespace PostgresGraphqlDemo.API.Utility
{
    public static class DbContextExtensions
    {
        public static void ConfigureDbContextOptions(DbContextOptionsBuilder options, string connectionString, IWebHostEnvironment environment)
        {
            // PostgreSQL database provider
            options.UseNpgsql(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorCodesToAdd: null
                );
            });

            if (environment.IsDevelopment())
            {
                options.EnableSensitiveDataLogging();
                options.LogTo(Log.Information, LogLevel.Information);
            }
            else
            {
                options.LogTo(Log.Information, LogLevel.Error);
            }
        }
    }
}
