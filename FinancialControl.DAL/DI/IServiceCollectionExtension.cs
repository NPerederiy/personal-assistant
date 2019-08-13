using FinancialControl.DAL.EF;
using FinancialControl.DAL.Repositories.Abstractions;
using FinancialControl.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialControl.DAL.DI
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<FinancialControlDbContext>(options => {
                options.UseLazyLoadingProxies()
                       .UseSqlServer(config.GetConnectionString("FinancialControlDb"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
