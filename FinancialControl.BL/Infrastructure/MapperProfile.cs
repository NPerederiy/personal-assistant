using AutoMapper;
using FinancialControl.BL.BO;
using FinancialControl.DAL.Entities;

namespace FinancialControl.BL.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Operation, OperationBO>();
            CreateMap<Category, CategoryBO>();
            CreateMap<User, UserBO>();

            CreateMap<OperationBO, Operation>();
            CreateMap<CategoryBO, Category>();
            CreateMap<UserBO, User>();
        }
    }
}
