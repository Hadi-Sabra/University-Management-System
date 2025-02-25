using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register infrastructure-level services here, such as file storage, external APIs, etc.
            // Example: services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}