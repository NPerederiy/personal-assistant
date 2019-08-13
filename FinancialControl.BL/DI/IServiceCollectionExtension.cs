using FinancialControl.DAL.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialControl.BL.DI
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddDataAccessLayer(config);

            return services;
        }
    }
}
