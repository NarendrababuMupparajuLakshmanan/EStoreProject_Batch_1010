using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Discount.Application
{
    public static class Dependencies
    {
        public static IServiceCollection
            RegisterServices(this IServiceCollection services)
        {

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });


            return services;
        }
    }
}
