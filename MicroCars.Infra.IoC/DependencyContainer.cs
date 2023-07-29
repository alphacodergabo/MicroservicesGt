using MediatR;
using MicroCars.Domain.Core.Bus;
using MicroCars.Infra.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace MicroCars.Infra.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var optionsFactory = sp.GetService<IOptions<RabbitMQSettings>>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, optionsFactory);
            });
            services.AddHttpClient("CarsForRent", config =>
            {
                config.BaseAddress = new Uri(configuration["Services:CarsForRent"]);
            });

            return services;
        }

    }
}
