using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinancialControl.BL.BO;
using FinancialControl.BL.Services.Abstractions;
using FinancialControl.DAL.Entities;
using FinancialControl.DAL.Repositories.Abstractions;

namespace FinancialControl.BL.Services.Implementations
{
    public class UserManager : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly ICategoryService _categoryService;

        public UserManager(
            IMapper mapper,
            IUnitOfWork uow,
            ICategoryService categoryService
        )
        {
            _mapper = mapper;
            _uow = uow;
            _categoryService = categoryService;
        }

        public async Task<UserBO> AddUserAsync(Guid id)
        {
            if ((await _uow.UserRepository.GetByConditionAsync(x => x.Id == id)).Any()) return null;

            var root = await _categoryService.CreateAsync("ROOT", null);

            var user = new User
            {
                Id = id,
                RootCategoryId = root.Id
            };

            await _uow.UserRepository.CreateAsync(user);
            return _mapper.Map<UserBO>(user);
        }

        public async Task<UserBO> GetUserAsync(Guid id)
        {
            var entity = await _uow.UserRepository.GetByConditionAsync(x => x.Id == id);
            return entity != null ? _mapper.Map<UserBO>(entity) : null;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = (await _uow.UserRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (user == null) return;

            await _categoryService.DeleteAsync(user.RootCategoryId);
            await _uow.UserRepository.DeleteAsync(user);
        }
    }
}
