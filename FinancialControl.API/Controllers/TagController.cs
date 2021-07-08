using System;
using System.Threading.Tasks;
using FinancialControl.API.Models;
using FinancialControl.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FinancialControl.API.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetAll(string userId)
        {
            if (userId == null || !Guid.TryParse(userId, out Guid guid)) return BadRequest();

            return Ok(await _tagService.GetAllTags(guid));
        }

        [HttpGet]
        public async Task<IActionResult> GetById(string tagId)
        {
            if (tagId == null || !Guid.TryParse(tagId, out Guid guid)) return BadRequest();

            return Ok(await _tagService.GetTag(guid));
        }

        [HttpPost]
        public async Task<IActionResult> AddTag(string name)
        {
            if (name == null) return BadRequest();

            await _tagService.CreateTag(name);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> RenameTag(TransactionTagModel model)
        {
            if (!ModelState.IsValid || !Guid.TryParse(model.Id, out Guid guid)) return BadRequest();

            await _tagService.RenameTag(guid, model.Tag);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTag(string id)
        {
            if (id == null || !Guid.TryParse(id, out Guid guid)) return BadRequest();

            await _tagService.DeleteTag(guid);

            return Ok();
        }
    }
}