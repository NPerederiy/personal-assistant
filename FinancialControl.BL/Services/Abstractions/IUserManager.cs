using FinancialControl.BL.BO;
using System;
using System.Threading.Tasks;

namespace FinancialControl.BL.Services.Abstractions
{
    public interface IUserManager
    {
        Task<UserBO> AddUserAsync(Guid id);
        Task DeleteUserAsync(Guid id);
        Task<CategoryBO> GetCategoryTreeRootAsync(Guid userId);
    }
}
