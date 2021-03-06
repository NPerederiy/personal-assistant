﻿using FinancialControl.BL.Infrastructure;
using FinancialControl.BL.Services.Abstractions;
using FinancialControl.BL.Services.Implementations;
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

            var mapper = Mapper.Get();
            services.AddSingleton(mapper);

            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<ITagService, TagService>();

            return services;
        }
    }
}
