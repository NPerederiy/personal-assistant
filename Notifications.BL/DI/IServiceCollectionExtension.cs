using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notifications.BL.Services.Abstractions;
using Notifications.BL.Services.Implementations;
using System.Net;
using System.Net.Mail;

namespace Notifications.BL.DI
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddTransient((serviceProvider) =>
            {
                var config = serviceProvider.GetRequiredService<IConfiguration>();

                return new SmtpClient()
                {
                    Host = config.GetValue<string>("Email:Smtp:Host"),
                    Port = config.GetValue<int>("Email:Smtp:Port"),
                    EnableSsl = config.GetValue<bool>("Email:Smtp:Ssl"),
                    UseDefaultCredentials = config.GetValue<bool>("Email:Smtp:DefaultCredentials"),
                    Credentials = new NetworkCredential(
                        config.GetValue<string>("Email:Smtp:Username"),
                        config.GetValue<string>("Email:Smtp:Password")
                    )
                };
            });
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
