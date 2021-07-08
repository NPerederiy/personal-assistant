using FinancialControl.API.Models;
using FinancialControl.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinancialControl.API.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        [Route("getByCategory")]
        public async Task<IActionResult> GetCategoryTransactions(string categoryId)
        {
            if (categoryId == null || !Guid.TryParse(categoryId, out Guid guid)) return BadRequest();

            return Ok(await _transactionService.GetAll(guid));
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetTransactionById(string id)
        {
            if (id == null || !Guid.TryParse(id, out Guid guid)) return BadRequest();

            var transaction = await _transactionService.GetByIdAsync(guid);

            if (transaction != null) return Ok(transaction);
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddTransactionModel model)
        {
            if (!ModelState.IsValid || !Guid.TryParse(model.CategoryId, out Guid guid)) return BadRequest();

            /*var x = */await _transactionService.CreateAsync(model.Name, model.Cost, model.CurrencyCode, model.CommittedAt, model.Tags, guid);

            /*if (x != null)*/ return Ok();
            //else return BadRequest();
        }

        [HttpPut]
        [Route("rename")]
        public async Task<IActionResult> RenameTransaction(RenameTransactionModel model)
        {
            if (!ModelState.IsValid || !Guid.TryParse(model.Id, out Guid guid)) return BadRequest();

            await _transactionService.RenameAsync(guid, model.Name);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || !Guid.TryParse(id, out Guid guid)) return BadRequest();

            await _transactionService.DeleteAsync(guid);

            return Ok();
        }
    }
}