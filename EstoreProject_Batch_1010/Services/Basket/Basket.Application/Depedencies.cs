using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Basket.Application
{
    public static class Depedencies
    {
        public static IServiceCollection
            RegisterBasketServices(this IServiceCollection services)
        {

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });


            return services;
        }
    }
}
