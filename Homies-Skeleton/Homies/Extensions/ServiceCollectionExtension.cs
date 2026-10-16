using Homies.Services.Core.Contracts;
using Homies.Services.Core.Services;

namespace Homies.Web.Extensions
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
