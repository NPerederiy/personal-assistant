using FinancialControl.BL.BO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialControl.BL.Services.Abstractions
{
    public interface IOperationService
    {
        Task<IEnumerable<OperationBO>> GetAll(Guid categoryId);
        Task<OperationBO> GetByIdAsync(Guid id);
        Task CreateAsync(string name, decimal cost, string currencyCode, Guid categoryId);
        Task RenameAsync(Guid id, string name);
        Task DeleteAsync(Guid id);
    }
}
