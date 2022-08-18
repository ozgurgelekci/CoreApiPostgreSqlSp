using Infrastructure.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<PostgreSqlContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"));
            });

            var postgreSQLConnectionConfiguration = new PostgreSqlConfiguration(configuration.GetConnectionString("PostgreSQLConnection"));
            services.AddSingleton(postgreSQLConnectionConfiguration);
            return services;
        }
    }
}
