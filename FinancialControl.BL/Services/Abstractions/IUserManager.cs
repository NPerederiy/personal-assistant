﻿using FinancialControl.BL.BO;
using System;
using System.Threading.Tasks;

namespace FinancialControl.BL.Services.Abstractions
{
    public interface IUserManager
    {
        Task<UserBO> AddUserAsync(Guid id);
        Task<UserBO> GetUserAsync(Guid id);
        Task DeleteUserAsync(Guid id);
        //void RequestConfirmationToken();              -- TODO: Implement
        //bool ValidateConfirmationToken(string token); -- TODO: Implement
    }
}
