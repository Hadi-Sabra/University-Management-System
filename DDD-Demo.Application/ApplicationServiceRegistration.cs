using Microsoft.Extensions.DependencyInjection;

namespace Core.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application layer services here
            // Example: services.AddScoped<IStudentService, StudentService>();
            return services;
        }
    }
}