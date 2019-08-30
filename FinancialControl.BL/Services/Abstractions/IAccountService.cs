using FinancialControl.BL.BO;
using FinancialControl.BL.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialControl.BL.Services.Abstractions
{
    public interface IAccountService
    {
        Task<IEnumerable<SingleCurrencyAccountBO>> GetSingleCurrencyAccounts(Guid ownerId);
        Task<IEnumerable<MultiCurrencyAccountBO>> GetMultiCurrencyAccounts(Guid ownerId);
        Task AddSingleCurrencyAccount(Guid ownerId, string name, string currencyCode, string number = null, string validTo = null, BankCardType cardType = BankCardType.NotProvided);
        Task AddMultiCurrencyAccount(Guid ownerId, string name, string[] currencyCodes);
        Task<SingleCurrencyAccountBO> GetSingleCurrencyAccount(Guid accountId);
        Task<MultiCurrencyAccountBO> GetMultiCurrencyAccount(Guid accountId);
        Task RenameSingleCurrencyAccount(Guid accountId, string newName);
        Task RenameMultiCurrencyAccount(Guid accountId, string newName);
        Task DeleteSingleCurrencyAccount(Guid accountId);
        Task DeleteMultiCurrencyAccount(Guid accountId);
    }
}
