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
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CategoryService(
            IMapper mapper,
            IUnitOfWork uow
        )
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<IEnumerable<CategoryBO>> GetAll(Guid userId)
        {
            var root = await GetCategoryTreeRootAsync(userId);

            return root?.Subcategories;
        }

        public async Task<CategoryBO> GetByIdAsync(Guid id)
        {
            var entity = (await _uow.CategoryRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            return entity != null ? _mapper.Map<CategoryBO>(entity) : null;
        }

        public async Task<CategoryBO> CreateAsync(string name, Guid? parentCategoryId = null)
        {
            var newCategory = new Category
            {
                Name = name
            };

            if (parentCategoryId == null)
            {
                await _uow.CategoryRepository.CreateAsync(newCategory);
            }
            else
            {
                var parent = (await _uow.CategoryRepository.GetByConditionAsync(x => x.Id == parentCategoryId)).FirstOrDefault();
                if (parent == null) return null;
                parent.Subcategories.ToList().Add(newCategory);
                await _uow.CategoryRepository.UpdateAsync(parent);
            }

            return _mapper.Map<CategoryBO>(newCategory);
        }

        public async Task RenameAsync(Guid id, string name)
        {
            var entity = (await _uow.CategoryRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (entity != null)
            {
                entity.Name = name;
                await _uow.CategoryRepository.UpdateAsync(entity);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = (await _uow.CategoryRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (entity != null) await _uow.CategoryRepository.DeleteAsync(entity);
        }

        public async Task<decimal> GetCostsByCurrencyAsync(Guid categoryId, string currencyCode)
        {
            var entity = (await _uow.CategoryRepository.GetByConditionAsync(x => x.Id == categoryId)).FirstOrDefault();
            if (entity == null) return 0;

            var category = _mapper.Map<CategoryBO>(entity);
            decimal totalCosts = 0;

            CalcOperationCosts(category, totalCosts);

            return totalCosts;

            void CalcOperationCosts(CategoryBO cat, decimal sum)
            {
                foreach (var op in cat.Operations)
                {
                    if (op.Currency.ISO_4217_Code == currencyCode)
                        sum += op.Cost;
                }

                foreach (var c in cat.Subcategories)
                {
                    CalcOperationCosts(c, sum);
                }
            }
        }

        public async Task<CategoryBO> GetCategoryTreeRootAsync(Guid userId)
        {
            var entity = (await _uow.UserRepository.GetByConditionAsync(x => x.Id == userId)).FirstOrDefault();
            return entity != null ? await GetByIdAsync(entity.RootCategoryId) : null;
        }
    }
}
