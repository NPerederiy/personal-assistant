using AutoMapper;
using FinancialControl.BL.BO;
using FinancialControl.BL.Services.Abstractions;
using FinancialControl.DAL.Entities;
using FinancialControl.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControl.BL.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public TransactionService(
            IUnitOfWork uow, 
            IMapper mapper,
            ICategoryService categoryService
        )
        {
            _uow = uow;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IEnumerable<TransactionBO>> GetAll(Guid categoryId)
        {
            var category = await _categoryService.GetByIdAsync(categoryId);

            return category?.Transactions;
        }

        public async Task<TransactionBO> GetByIdAsync(Guid id)
        {
            var entity = (await _uow.TransactionRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            return entity != null ? _mapper.Map<TransactionBO>(entity) : null;
        }

        public async Task CreateAsync(string name, decimal cost, string currencyCode, Guid categoryId)
        {
            var category = await _categoryService.GetByIdAsync(categoryId);
            if (category == null) return;

            var entity = _mapper.Map<Category>(category);
            entity.Transactions.ToList().Add(new Transaction
            {
                Name = name,
                Cost = cost,
                CurrencyCode = currencyCode
            });

            await _uow.CategoryRepository.UpdateAsync(entity);
        }

        public async Task RenameAsync(Guid id, string name)
        {
            var entity = (await _uow.TransactionRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (entity != null)
            {
                entity.Name = name;
                await _uow.TransactionRepository.UpdateAsync(entity);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = (await _uow.TransactionRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            await _uow.TransactionRepository.DeleteAsync(entity);
        }
    }
}
