using AutoMapper;
using FinancialControl.BL.BO;
using FinancialControl.BL.Enums;
using FinancialControl.BL.Extensions;
using FinancialControl.BL.Services.Abstractions;
using FinancialControl.DAL.Entities;
using FinancialControl.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControl.BL.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public AccountService(
            IUnitOfWork uow,
            IUserManager userManager,
            IMapper mapper
        )
        {
            _uow = uow;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SingleCurrencyAccountBO>> GetSingleCurrencyAccounts(Guid ownerId)
        {
            var user = await _userManager.GetUserAsync(ownerId);
            return user?.SingleCurrencyAccounts;
        }

        public async Task<IEnumerable<MultiCurrencyAccountBO>> GetMultiCurrencyAccounts(Guid ownerId)
        {
            var user = await _userManager.GetUserAsync(ownerId);
            return user?.MultiCurrencyAccounts;
        }

        public async Task<MultiCurrencyAccountBO> GetMultiCurrencyAccount(Guid accountId)
        {
            var entity = await GetMultiCurrencyAccountEntity(accountId);
            return entity != null ? _mapper.Map<MultiCurrencyAccountBO>(entity) : null;
        }

        public async Task<SingleCurrencyAccountBO> GetSingleCurrencyAccount(Guid accountId)
        {
            var entity = await GetSingleCurrencyAccountEntity(accountId);
            return entity != null ? _mapper.Map<SingleCurrencyAccountBO>(entity) : null;
        }

        public async Task AddMultiCurrencyAccount(Guid ownerId, string name, string[] currencyCodes)
        {
            var owner = (await _uow.UserRepository.GetByConditionAsync(x => x.Id == ownerId)).FirstOrDefault();
            if (owner == null) return;

            var accounts = new HashSet<SingleCurrencyAccount>();
            foreach (var code in currencyCodes)
            {
                accounts.Add(await BuildSingleCurrencyAccountEntity(ownerId, name, code));
            }

            var entity = new MultiCurrencyAccount
            {
                Name = name,
                Owner = owner,
                Accounts = accounts
            };

            await _uow.McaRepository.CreateAsync(entity);
        }

        public async Task AddSingleCurrencyAccount(Guid ownerId, string name, string currencyCode, string number = null, string validTo = null, BankCardType cardType = BankCardType.NotProvided)
        {
            var entity = await BuildSingleCurrencyAccountEntity(ownerId, name, currencyCode, number, validTo, cardType);
            if (entity == null) return;

            await _uow.ScaRepository.CreateAsync(entity);
        }

        public async Task RenameMultiCurrencyAccount(Guid accountId, string newName)
        {
            var entity = await GetMultiCurrencyAccountEntity(accountId);
            if (entity == null) return;

            entity.Name = newName;

            await _uow.McaRepository.UpdateAsync(entity);
        }

        public async Task RenameSingleCurrencyAccount(Guid accountId, string newName)
        {
            var entity = await GetSingleCurrencyAccountEntity(accountId);
            if (entity == null) return;

            entity.Name = newName;

            await _uow.ScaRepository.UpdateAsync(entity);
        }

        public async Task DeleteMultiCurrencyAccount(Guid accountId)
        {
            var entity = await GetMultiCurrencyAccountEntity(accountId);
            if (entity == null) return;

            await _uow.McaRepository.DeleteAsync(entity);
        }

        public async Task DeleteSingleCurrencyAccount(Guid accountId)
        {
            var entity = await GetSingleCurrencyAccountEntity(accountId);
            if (entity == null) return;

            await _uow.ScaRepository.DeleteAsync(entity);
        }

        private async Task<SingleCurrencyAccount> GetSingleCurrencyAccountEntity(Guid accountId)
        {
            return (await _uow.ScaRepository.GetByConditionAsync(x => x.Id == accountId)).FirstOrDefault();
        }

        private async Task<MultiCurrencyAccount> GetMultiCurrencyAccountEntity(Guid accountId)
        {
            return (await _uow.McaRepository.GetByConditionAsync(x => x.Id == accountId)).FirstOrDefault();
        }

        private async Task<SingleCurrencyAccount> BuildSingleCurrencyAccountEntity(Guid ownerId, string name, string currencyCode, string number = null, string validTo = null, BankCardType cardType = BankCardType.NotProvided)
        {
            var owner = (await _uow.UserRepository.GetByConditionAsync(x => x.Id == ownerId)).FirstOrDefault();
            if (owner == null) return null;

            var currency = (await _uow.CurrencyRepository.GetByConditionAsync(x => x.ISO_4217_Code == currencyCode)).FirstOrDefault();
            if (currency == null) return null;

            var account = new SingleCurrencyAccount
            {
                Owner = owner,
                Name = name,
                Balance = 0,
                Currency = currency,
                Number = number,
                ValidTo = validTo,
                CardType = cardType.GetName()
            };

            return account;
        }
    }
}
