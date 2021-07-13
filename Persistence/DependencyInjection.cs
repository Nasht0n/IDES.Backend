using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<IdesDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
            services.AddScoped<IDbContext>(provider => provider.GetService<IdesDbContext>());
            return services;
        }
    }
}
