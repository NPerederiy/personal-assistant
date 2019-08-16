using System;
using System.Threading.Tasks;
using FinancialControl.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FinancialControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public AccountController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string userId)
        {
            if (userId == null || !Guid.TryParse(userId, out Guid guid)) return BadRequest();

            await _userManager.AddUserAsync(guid);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] string userId)
        {
            if (userId == null || !Guid.TryParse(userId, out Guid guid)) return BadRequest();

            await _userManager.DeleteUserAsync(guid);

            return Ok();
        }
    }
}
