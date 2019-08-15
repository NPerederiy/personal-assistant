using FinancialControl.BL.BO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialControl.BL.Services.Abstractions
{
    public interface IOperationService
    {
        IEnumerable<OperationBO> GetAll();
        Task<OperationBO> GetByIdAsync(Guid id);
        Task CreateAsync(string name, decimal cost, string currencyCode, Guid categoryId);
        Task UpdateAsync(OperationBO entity);
        Task DeleteAsync(Guid id);
    }
}
