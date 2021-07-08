using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.Models.Commands.Abstractions;
using TelegramBot.Models.Commands.Implementations;

namespace TelegramBot.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commands;

        public static IReadOnlyList<Command> Commands => commands.AsReadOnly();

        public static async Task<TelegramBotClient> GetClientAsync()
        {
            if (client != null) return client;

            commands = new List<Command>
            {
                new HelloCommand()

                // TODO: Add more commands
            };

            client = new TelegramBotClient(BotConfig.Key);
            var hook = string.Format(BotConfig.Url, "api/message/update");
            await client.SetWebhookAsync(hook);

            return client;
        }
    }
}
