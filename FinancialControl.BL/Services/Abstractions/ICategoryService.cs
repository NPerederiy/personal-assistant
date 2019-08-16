using FinancialControl.BL.BO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialControl.BL.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryBO>> GetAll(Guid userId);
        Task<CategoryBO> GetByIdAsync(Guid id);
        Task<CategoryBO> CreateAsync(string name, Guid? parentCategoryId = null);
        Task RenameAsync(Guid id, string name);
        Task DeleteAsync(Guid id);
        Task<decimal> GetCostsByCurrencyAsync(Guid categoryId, string currencyCode);
        Task<CategoryBO> GetCategoryTreeRootAsync(Guid userId);
    }
}
