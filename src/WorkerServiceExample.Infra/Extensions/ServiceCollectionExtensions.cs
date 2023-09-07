// Em WorkerServiceExample.Infrastructure/ServiceCollectionExtensions.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkerServiceExample.Data.Contexts;
using WorkerServiceExample.Data.Repository;

namespace WorkerServiceExample.Infra.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ServiceDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ServiceDbConnection"));
            });
            services.AddDbContext<InfraDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("InfraDbConnection"));
            });
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Adicione outras injeções de dependência aqui, se necessário
            services.AddScoped<ItemRepository>();
            services.AddScoped<ItemService>();
            services.AddScoped<TestRepository>();
            services.AddScoped<TestService>();
            return services;
        }
    }
}
