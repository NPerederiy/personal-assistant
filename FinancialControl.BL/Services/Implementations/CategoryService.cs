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

        public IEnumerable<CategoryBO> GetAll()
        {
            var entities = _uow.CategoryRepository.GetAll().ToList();
            var list = new List<CategoryBO>();

            foreach (var entity in entities)
                list.Add(_mapper.Map<CategoryBO>(entity));

            return list;
        }

        public async Task<CategoryBO> GetByIdAsync(Guid id)
        {
            var entity = (await _uow.CategoryRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            return entity != null ? _mapper.Map<CategoryBO>(entity) : null;
        }

        public async Task<CategoryBO> CreateAsync(string name, CategoryBO parentCategory = null)
        {
            var newCategory = new Category
            {
                Name = name
            };

            if (parentCategory == null)
            {
                await _uow.CategoryRepository.CreateAsync(newCategory);
            }
            else
            {
                var parent = _mapper.Map<Category>(parentCategory);
                parent.Subcategories.ToList().Add(newCategory);
                await _uow.CategoryRepository.UpdateAsync(parent);
            }

            return _mapper.Map<CategoryBO>(newCategory);
        }

        public async Task UpdateAsync(CategoryBO category)
        {
            var entity = (await _uow.CategoryRepository.GetByConditionAsync(x => x.Id == category.Id)).FirstOrDefault();
            if (entity != null)
            {
                entity = _mapper.Map<Category>(category);
                await _uow.CategoryRepository.UpdateAsync(entity);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = (await _uow.CategoryRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (entity != null) await _uow.CategoryRepository.DeleteAsync(entity);
        }

        public decimal GetCostsByCurrencyAsync(CategoryBO category, string currencyCode)
        {
            decimal totalCosts = 0;

            Calc(category, totalCosts);

            return totalCosts;

            void Calc(CategoryBO cat, decimal sum)
            {
                sum = CalcOperationCosts(cat, sum);
                foreach (var c in cat.Subcategories)
                {
                    Calc(c, sum);
                }
            }

            decimal CalcOperationCosts(CategoryBO cat, decimal sum)
            {
                foreach (var op in cat.Operations)
                    if (op.Currency.ISO_4217_Code == currencyCode)
                        sum += op.Cost;
                return sum;
            }
        }
    }
}
