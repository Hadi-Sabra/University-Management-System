using Microsoft.Extensions.DependencyInjection;

namespace Core.Domain
{
    public static class DomainServiceRegistration
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // Register domain-level services here
            // For example: domain event handlers, validators, etc.
            
            return services;
        }
    }
}