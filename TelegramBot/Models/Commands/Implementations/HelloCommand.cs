using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Models.Commands.Abstractions;

namespace TelegramBot.Models.Commands.Implementations
{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            await client.SendTextMessageAsync(chatId, $"Hello! I'm {BotConfig.Name}");
        }
    }
}
