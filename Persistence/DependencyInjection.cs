using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<Apps_DbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<I_DbContext>(provider =>
                provider.GetService<Apps_DbContext>());
            return services;
        }
    }
}
