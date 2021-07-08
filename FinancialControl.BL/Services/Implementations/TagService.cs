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
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public TagService(
            IUnitOfWork uow,
            IMapper mapper,
            ICategoryService categoryService
        )
        {
            _uow = uow;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IEnumerable<TagBO>> GetAllTags(Guid userId)
        {
            var root = await _categoryService.GetCategoryTreeRootAsync(userId);
            if (root == null) return null;

            var tags = new HashSet<TagBO>();

            foreach (var tag in from c in root.Subcategories
                                from t in c.Transactions
                                from tag in t.Tags
                                where !tags.Contains(tag)
                                select tag)
            {
                tags.Add(tag);
            }

            return tags;
        }

        public async Task<TagBO> GetTag(Guid tagId)
        {
            var entity = await _uow.TagRepository.GetByConditionAsync(x => x.Id == tagId);
            return entity != null ? _mapper.Map<TagBO>(entity) : null;
        }

        public async Task<TagBO> GetTag(string name)
        {
            var entity = await _uow.TagRepository.GetByConditionAsync(x => x.Name == name);
            return entity != null ? _mapper.Map<TagBO>(entity) : null;
        }

        public async Task<TagBO> CreateTag(string name)
        {
            var tag = new Tag
            {
                Name = name
            };

            await _uow.TagRepository.CreateAsync(tag);
            return _mapper.Map<TagBO>(tag);
        }

        public async Task RenameTag(Guid tagId, string newName)
        {
            var tag = (await _uow.TagRepository.GetByConditionAsync(x => x.Id == tagId)).FirstOrDefault();
            if (tag == null) return;

            tag.Name = newName;

            await _uow.TagRepository.UpdateAsync(tag);
        }

        public async Task DeleteTag(Guid tagId)
        {
            var entity = (await _uow.TagRepository.GetByConditionAsync(x => x.Id == tagId)).FirstOrDefault();
            await _uow.TagRepository.DeleteAsync(entity);
        }
    }
}
