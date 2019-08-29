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
        private readonly ISmsSender _smsSender;

        public NotificationController(
            IEmailSender emailSender,
            ISmsSender smsSender
        )
        {
            _emailSender = emailSender;
            _smsSender = smsSender;
        }

        [HttpPost]
        [Route("email")]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _emailSender.SendMailAsync(model.Recipient, model.Subject, model.Message);

            return Ok();
        }

        [HttpPost]
        [Route("sms")]
        public async Task<IActionResult> SendSms([FromBody] SendSmsModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _smsSender.SendSmsAsync(model.Recipient, model.Message);

            return Ok();
        }
    }
}
