using System;
using System.Threading.Tasks;
using FinancialControl.API.Models;
using FinancialControl.BL.Extensions;
using FinancialControl.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FinancialControl.API.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("singleCurrency")]
        public async Task<IActionResult> GetSingleCurrencyAccounts(string ownerId)
        {
            if (ownerId == null || !Guid.TryParse(ownerId, out Guid guid)) return BadRequest();

            var accounts = await _accountService.GetSingleCurrencyAccounts(guid);
            if (accounts == null) return NotFound();
    
            return Ok(accounts);
        }

        [HttpGet]
        [Route("multiCurrency")]
        public async Task<IActionResult> GetMultiCurrencyAccounts(string ownerId)
        {
            if (ownerId == null || !Guid.TryParse(ownerId, out Guid guid)) return BadRequest();

            var accounts = await _accountService.GetMultiCurrencyAccounts(guid);
            if (accounts == null) return NotFound();

            return Ok(accounts);
        }

        [HttpGet]
        [Route("singleCurrency/{ownerId}")]
        public async Task<IActionResult> GetSingleCurrencyAccount(string ownerId)
        {
            if (ownerId == null || !Guid.TryParse(ownerId, out Guid guid)) return BadRequest();

            var accounts = await _accountService.GetSingleCurrencyAccount(guid);
            if (accounts == null) return NotFound();

            return Ok(accounts);
        }

        [HttpGet]
        [Route("multiCurrency/{ownerId}")]
        public async Task<IActionResult> GetMultiCurrencyAccount(string ownerId)
        {
            if (ownerId == null || !Guid.TryParse(ownerId, out Guid guid)) return BadRequest();

            var accounts = await _accountService.GetMultiCurrencyAccount(guid);
            if (accounts == null) return NotFound();

            return Ok(accounts);
        }

        [HttpPost]
        [Route("singleCurrency")]
        public async Task<IActionResult> AddSingleCurrencyAccount(AddSCAModel model)
        {
            if (!ModelState.IsValid || !Guid.TryParse(model.OwnerId, out Guid guid)) return BadRequest();

            await _accountService.AddSingleCurrencyAccount(guid, model.Name, model.CurrencyCode, model.AccountNumber, model.ValidTo, model.BankCardType.ToBankCardTypeEnum());

            return Ok();
        }

        [HttpPost]
        [Route("multiCurrency")]
        public async Task<IActionResult> AddMultiCurrencyAccount(AddMCAModel model)
        {
            if (!ModelState.IsValid || !Guid.TryParse(model.OwnerId, out Guid guid)) return BadRequest();

            await _accountService.AddMultiCurrencyAccount(guid, model.Name, model.CurrencyCodes);

            return Ok();
        }

        [HttpPut]
        [Route("singleCurrency/rename")]
        public async Task<IActionResult> RenameSingleCurrencyAccount(RenameAccountModel model)
        {
            if (!ModelState.IsValid || !Guid.TryParse(model.AccountId, out Guid guid)) return BadRequest();

            await _accountService.RenameSingleCurrencyAccount(guid, model.NewName);

            return Ok();
        }

        [HttpPut]
        [Route("multiCurrency/rename")]
        public async Task<IActionResult> RenameMultiCurrencyAccount(RenameAccountModel model)
        {
            if (!ModelState.IsValid || !Guid.TryParse(model.AccountId, out Guid guid)) return BadRequest();

            await _accountService.RenameMultiCurrencyAccount(guid, model.NewName); 

            return Ok();
        }

        [HttpDelete]
        [Route("singleCurrency/{id}")]
        public async Task<IActionResult> DeleteSingleCurrencyAccount(string accountId)
        {
            if (accountId == null || !Guid.TryParse(accountId, out Guid guid)) return BadRequest();

            await _accountService.DeleteSingleCurrencyAccount(guid);

            return Ok();
        }

        [HttpDelete]
        [Route("multiCurrency/{id}")]
        public async Task<IActionResult> DeleteMultiCurrencyAccount(string accountId)
        {
            if (accountId == null || !Guid.TryParse(accountId, out Guid guid)) return BadRequest();

            await _accountService.DeleteMultiCurrencyAccount(guid);

            return Ok();
        }
    }
}