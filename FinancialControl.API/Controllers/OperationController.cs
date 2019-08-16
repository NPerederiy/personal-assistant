using FinancialControl.API.Models;
using FinancialControl.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinancialControl.API.Controllers
{
    public class OperationController : Controller
    {
        private readonly IOperationService _operationService;

        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        [Route("getByCategory")]
        public async Task<IActionResult> GetCategoryOperations(string categoryId)
        {
            if (categoryId == null || !Guid.TryParse(categoryId, out Guid guid)) return BadRequest();

            return Ok(await _operationService.GetAll(guid));
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetOperationById(string id)
        {
            if (id == null || !Guid.TryParse(id, out Guid guid)) return BadRequest();

            var operation = await _operationService.GetByIdAsync(guid);

            if (operation != null) return Ok(operation);
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddOperationModel model)
        {
            if (!ModelState.IsValid || !Guid.TryParse(model.CategoryId, out Guid guid)) return BadRequest();

            /*var x = */await _operationService.CreateAsync(model.Name, model.Cost, model.CurrencyCode, guid);

            /*if (x != null)*/ return Ok();
            //else return BadRequest();
        }

        [HttpPut]
        [Route("rename")]
        public async Task<IActionResult> RenameOperation(RenameOperationModel model)
        {
            if (!ModelState.IsValid || !Guid.TryParse(model.Id, out Guid guid)) return BadRequest();

            await _operationService.RenameAsync(guid, model.Name);

            return Ok();
        }



        [HttpPut]
        [Route("addMarker")]
        public async Task<IActionResult> AddMarker(OperationMarkerModel model)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("removeMarker")]
        public async Task<IActionResult> RemoveMarker(OperationMarkerModel model)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || !Guid.TryParse(id, out Guid guid)) return BadRequest();

            await _operationService.DeleteAsync(guid);

            return Ok();
        }
    }
}