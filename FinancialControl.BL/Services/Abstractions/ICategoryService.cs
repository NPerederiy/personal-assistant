using FinancialControl.BL.BO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialControl.BL.Services.Abstractions
{
    public interface ICategoryService
    {
        IEnumerable<CategoryBO> GetAll();
        Task<CategoryBO> GetByIdAsync(Guid id);
        Task<CategoryBO> CreateAsync(string name, CategoryBO parentCategory = null);
        Task UpdateAsync(CategoryBO entity);
        Task DeleteAsync(Guid id);
        decimal GetCostsByCurrencyAsync(CategoryBO category, string currencyCode);
    }
}
