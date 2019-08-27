using AutoMapper;
using FinancialControl.BL.BO;
using FinancialControl.DAL.Entities;

namespace FinancialControl.BL.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Transaction, TransactionBO>();
            CreateMap<Category, CategoryBO>();
            CreateMap<User, UserBO>(); // TODO: Add manual mapping of tags
            CreateMap<Tag, TagBO>();

            CreateMap<TransactionBO, Transaction>();
            CreateMap<CategoryBO, Category>();
            CreateMap<UserBO, User>(); // TODO: Add manual mapping of tags
            CreateMap<TagBO, Tag>();
        }
    }
}
