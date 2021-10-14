using Microsoft.Extensions.DependencyInjection;
using Whatever.EventLike.Application.Projection;
using Whatever.EventLike.Application.Transport;

namespace Whatever.EventLike.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterComponents(this IServiceCollection services)
        {
            services.AddHostedService<ProjectionBackgroundService>();
            services.AddScoped<CountersService>();

            services.AddSingleton<EventChannel>();
        }
    }
}