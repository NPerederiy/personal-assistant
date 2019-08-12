using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBot.Models;

namespace TelegramBot.Controllers
{
    [ApiController]
    [Route("api/message/update")]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            if (!ModelState.IsValid) return BadRequest();

            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.GetClientAsync();

            foreach (var c in commands)
            {
                if (c.Contains(message.Text))
                {
                    await c.Execute(message, client);
                    break;
                }
            }

            return Ok();
        }
    }
}