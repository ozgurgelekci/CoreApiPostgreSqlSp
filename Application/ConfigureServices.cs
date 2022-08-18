using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddFluentValidation(conf =>
            {
                conf.RegisterValidatorsFromAssembly(typeof(ConfigureServices).Assembly);
            });

            return services;
        }
    }
}
