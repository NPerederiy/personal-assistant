using Notifications.BL.Services.Abstractions;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Notifications.BL.Services.Implementations
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpClient _client;
        private readonly string _sender;
        private readonly string _signature;

        public EmailSender(
            SmtpClient smtpClient,
            string senderEmail    
        )
        {
            _client = smtpClient;
            _sender = senderEmail;
            _signature = "Your personal assistant";
        }

        public async Task SendMailAsync(string recipient, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(recipient);
            mail.From = new MailAddress(_sender);
            mail.Subject = subject;
            mail.Body = $"{message} <br><br> {_signature}";
            mail.IsBodyHtml = true;

            await _client.SendMailAsync(mail);
        }
    }
}
