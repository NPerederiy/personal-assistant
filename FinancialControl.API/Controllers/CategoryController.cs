using System;
using System.Threading.Tasks;
using FinancialControl.API.Models;
using FinancialControl.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FinancialControl.API.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("user/id")]
        public async Task<IActionResult> GetRootCategories(string userId)
        {
            if (userId == null || !Guid.TryParse(userId, out Guid guid)) return BadRequest();

            return Ok(await _categoryService.GetAll(guid));
        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetById(string id)
        {
            if (id == null || !Guid.TryParse(id, out Guid guid)) return BadRequest();

            var category = await _categoryService.GetByIdAsync(guid);

            if (category != null) return Ok(category);
            else return NotFound();
        }

        [HttpGet]
        [Route("costs/currency")]
        public async Task<IActionResult> GetOperationCostsByCurrency(string categoryId, string currencyCode)
        {
            if (categoryId == null || currencyCode == null || !Guid.TryParse(categoryId, out Guid guid)) return BadRequest();

            var costs = await _categoryService.GetCostsByCurrencyAsync(guid, currencyCode);

            return Ok(costs);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCategoryModel model)
        {
            if (!ModelState.IsValid || !Guid.TryParse(model.ParentCategoryId, out Guid guid)) return BadRequest();

            var x = await _categoryService.CreateAsync(model.Name, guid);

            if (x != null) return Ok();
            else return BadRequest();
        }

        [HttpPut]
        [Route("name")]
        public async Task<IActionResult> Put([FromBody] RenameCategoryModel model)
        {
            if (!ModelState.IsValid || !Guid.TryParse(model.Id, out Guid guid)) return BadRequest();

            await _categoryService.RenameAsync(guid, model.Name);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || !Guid.TryParse(id, out Guid guid)) return BadRequest();

            await _categoryService.DeleteAsync(guid);

            return Ok();
        }
    }
}