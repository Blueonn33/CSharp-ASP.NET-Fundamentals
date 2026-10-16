using Homies.Services.Core.Contracts;
using Homies.Services.Core.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
            return services;
        }
    }
}
