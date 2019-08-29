using System.Threading.Tasks;

namespace Notifications.BL.Services.Abstractions
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
