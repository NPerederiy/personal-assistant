namespace TelegramBot.Models
{
    public static class BotConfig
    {
        public static string Url { get; }
        public static string Name { get; }
        public static string Key { get; }

        static BotConfig()
        {
            Url = "https://telegrambotapp.azurewebsites.net:433/{0}";
            Name = "Jessie";
            Key = "telegram-bot-key";
        }
    }
}
