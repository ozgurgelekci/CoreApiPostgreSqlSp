using Application.Common.Interfaces;
using Infrastructure.Persistance;

namespace WebAPI
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebUIServices(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // services DI
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
