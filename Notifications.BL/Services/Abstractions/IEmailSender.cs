using System.Threading.Tasks;

namespace Notifications.BL.Services.Abstractions
{
    public interface IEmailSender
    {
        Task SendMailAsync(string email, string subject, string message);
    }
}
