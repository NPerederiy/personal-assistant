using Notifications.BL.Services.Abstractions;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Notifications.BL.Services.Implementations
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpClient _client;
        private readonly string _sender = "tasktrackingsyst@gmail.com";
        private readonly string _signature = "Your personal assistant";

        public EmailSender(SmtpClient smtpClient)
        {
            _client = smtpClient;
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
