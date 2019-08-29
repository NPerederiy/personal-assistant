using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notifications.BL.Services.Abstractions;
using Notifications.BL.Services.Implementations;
using System.Net;
using System.Net.Mail;
using Twilio.Clients;

namespace Notifications.BL.DI
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration config)
        {
            var senderEmail = config.GetValue<string>("Email:Smtp:Username");
            var senderPhone = config.GetValue<string>("Twilio:SenderPhone");

            services.AddTransient((serviceProvider) =>
            {
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

            services.AddHttpClient<ITwilioRestClient, CustomTwilioClient>();
            services.AddTransient<IEmailSender>(x => { return ActivatorUtilities.CreateInstance<EmailSender>(x, senderEmail); });
            services.AddTransient<ISmsSender>(x => { return ActivatorUtilities.CreateInstance<SmsSender>(x, senderPhone); });

            return services;
        }
    }
}
