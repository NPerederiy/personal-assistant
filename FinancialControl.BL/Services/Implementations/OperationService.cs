﻿using AutoMapper;
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
    public class OperationService : IOperationService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public OperationService(
            IUnitOfWork uow, 
            IMapper mapper,
            ICategoryService categoryService
        )
        {
            _uow = uow;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IEnumerable<OperationBO>> GetAll(Guid categoryId)
        {
            var category = await _categoryService.GetByIdAsync(categoryId);

            return category?.Operations;
        }

        public async Task<OperationBO> GetByIdAsync(Guid id)
        {
            var entity = (await _uow.OperationRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            return entity != null ? _mapper.Map<OperationBO>(entity) : null;
        }

        public async Task CreateAsync(string name, decimal cost, string currencyCode, Guid categoryId)
        {
            var category = await _categoryService.GetByIdAsync(categoryId);
            if (category == null) return;

            var entity = _mapper.Map<Category>(category);
            entity.Operations.ToList().Add(new Operation
            {
                Name = name,
                Cost = cost,
                CurrencyCode = currencyCode
            });

            await _uow.CategoryRepository.UpdateAsync(entity);
        }

        public async Task RenameAsync(Guid id, string name)
        {
            var entity = (await _uow.OperationRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (entity != null)
            {
                entity.Name = name;
                await _uow.OperationRepository.UpdateAsync(entity);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = (await _uow.OperationRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            await _uow.OperationRepository.DeleteAsync(entity);
        }
    }
}
