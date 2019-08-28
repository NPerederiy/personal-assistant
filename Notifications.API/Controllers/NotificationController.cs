using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notifications.API.Models;
using Notifications.BL.Services.Abstractions;

namespace Notifications.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public NotificationController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route("email")]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _emailSender.SendMailAsync(model.Recipient, model.Subject, model.Message);

            return Ok();
        }
    }
}
