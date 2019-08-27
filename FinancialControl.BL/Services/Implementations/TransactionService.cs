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
        private readonly ITagService _tagService;

        public TransactionService(
            IUnitOfWork uow, 
            IMapper mapper,
            ICategoryService categoryService,
            ITagService tagService
        )
        {
            _uow = uow;
            _mapper = mapper;
            _categoryService = categoryService;
            _tagService = tagService;
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

        public async Task CreateAsync(string name, decimal cost, string currencyCode, DateTime commitedAt, string[] tags, Guid categoryId)
        {
            var category = (await _uow.CategoryRepository.GetByConditionAsync(x => x.Id == categoryId)).FirstOrDefault();
            if (category == null) return;

            var createdAt = DateTime.UtcNow;
            var transaction = new Transaction
            {
                Name = name,
                Cost = cost,
                CurrencyCode = currencyCode,
                CreatedAt = createdAt,
                UpdatedAt = createdAt,
                CommitedAt = commitedAt,
            };

            category.Transactions.ToList().Add(transaction);
            await _uow.CategoryRepository.UpdateAsync(category);

            var transactionTags = new HashSet<TransactionTags>();
            foreach (var tagName in tags)
            {
                var tag = await _tagService.GetTag(tagName);
                transactionTags.Add(new TransactionTags {
                    TransactionId = transaction.Id,
                    TagId = tag.Id
                });
            }

            transaction.TransactionTags = transactionTags;
            await _uow.TransactionRepository.UpdateAsync(transaction);
        }

        public async Task RenameAsync(Guid id, string name)
        {
            var entity = (await _uow.TransactionRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (entity != null)
            {
                entity.Name = name;
                entity.UpdatedAt = DateTime.UtcNow;
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
