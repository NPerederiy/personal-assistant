using FinancialControl.BL.BO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialControl.BL.Services.Abstractions
{
    public interface ITagService
    {
        Task<IEnumerable<TagBO>> GetAllTags(Guid userId);
        Task<TagBO> GetTag(Guid tagId);
        Task<TagBO> GetTag(string name);
        Task<TagBO> CreateTag(string name);
        Task RenameTag(Guid tagId, string newName);
        Task DeleteTag(Guid tagId);
    }
}
