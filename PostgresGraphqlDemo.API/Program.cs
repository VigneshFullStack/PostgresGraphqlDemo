using PostgresGraphqlDemo.API.ApplicationDbContext;
using PostgresGraphqlDemo.API.BusinessService;
using PostgresGraphqlDemo.API.Repository;
using PostgresGraphqlDemo.API.Resolvers;
using PostgresGraphqlDemo.API.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddPooledDbContextFactory<DataContext>(options =>
{
    DbContextExtensions.ConfigureDbContextOptions(options, connectionString!, builder.Environment);
});

builder.Services.AddScoped<IDataContext>(provider =>
{
    var factory = provider.GetRequiredService<IDbContextFactory<DataContext>>();
    return factory.CreateDbContext();
});

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration);
//builder.Services.AddAuthorization();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IAuditService, AuditService>();

builder.Services.AddHttpContextAccessor();
builder.Services
    .AddGraphQLServer()
    //.AddAuthorization()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var allowedOrigins = builder.Configuration.GetSection("AllowedCorsOrigins").Get<string[]>();

builder.Services.AddCors(options =>
    options.AddPolicy("CorsPolicy", build =>
        build.WithOrigins(allowedOrigins)
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL("/api/graphql");
});

app.MapGraphQL();

app.Run();
