using Notifications.BL.Services.Abstractions;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Notifications.BL.Services.Implementations
{
    public class SmsSender : ISmsSender
    {
        private readonly ITwilioRestClient _client;
        private readonly string _sender;

        public SmsSender(
            ITwilioRestClient client,
            string senderPhone
        )
        {
            _client = client;
            _sender = senderPhone;
        }

        public async Task SendSmsAsync(string number, string message)
        {
            await MessageResource.CreateAsync(
                to: new PhoneNumber(number),
                from: new PhoneNumber(_sender),
                body: message,
                client: _client
            );
        }
    }
}
