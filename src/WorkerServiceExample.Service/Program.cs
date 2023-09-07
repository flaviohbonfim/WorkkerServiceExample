using WorkerServiceExample.Infra.Extensions;

namespace WorkerServiceExample.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddCustomDbContext(hostContext.Configuration);
                    // Use o método de extensão AddInfrastructure para configurar a injeção de dependência
                    services.AddInfrastructure();

                    // Configura o Worker como serviço hospedado
                    services.AddHostedService<Worker>();

                    services.AddLogging(builder =>
                    {
                        builder.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
                    });
                });
    }
}
