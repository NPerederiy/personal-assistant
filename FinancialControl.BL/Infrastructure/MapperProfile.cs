using AutoMapper;
using FinancialControl.BL.BO;
using FinancialControl.BL.Extensions;
using FinancialControl.DAL.Entities;
using System.Collections.Generic;

namespace FinancialControl.BL.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Transaction, TransactionBO>()
                .ForMember(o => o.Tags, obj => obj.MapFrom(o => GetTags(o.TransactionTags)));
            CreateMap<Category, CategoryBO>();
            CreateMap<User, UserBO>();
            CreateMap<Tag, TagBO>()
                .ForMember(o => o.Transactions, obj => obj.MapFrom(o => GetTransactions(o.TransactionTags)));
            CreateMap<SingleCurrencyAccount, SingleCurrencyAccountBO>()
                .ForMember(o => o.CardType, obj => obj.MapFrom(o => o.CardType.ToBankCardTypeEnum()));
            CreateMap<MultiCurrencyAccount, MultiCurrencyAccountBO>();

            CreateMap<TransactionBO, Transaction>()
                .ForMember(o => o.TransactionTags, obj => obj.MapFrom(o => GetTransactionTags(o)));
            CreateMap<CategoryBO, Category>();
            CreateMap<UserBO, User>();
            CreateMap<TagBO, Tag>()
                .ForMember(o => o.TransactionTags, obj => obj.MapFrom(o => GetTransactionTags(o)));
            CreateMap<SingleCurrencyAccountBO, SingleCurrencyAccount>()
                .ForMember(o => o.CardType, obj => obj.MapFrom(o => o.CardType.GetName()));
            CreateMap<MultiCurrencyAccountBO, MultiCurrencyAccountBO>();
        }

        private HashSet<TransactionTags> GetTransactionTags(TransactionBO transaction)
        {
            var set = new HashSet<TransactionTags>();
            foreach(var tag in transaction.Tags)
            {
                set.Add(new TransactionTags
                {
                    TransactionId = transaction.Id,
                    TagId = tag.Id
                });
            }
            return set;
        }

        private HashSet<TransactionTags> GetTransactionTags(TagBO tag)
        {
            var set = new HashSet<TransactionTags>();
            foreach (var transaction in tag.Transactions)
            {
                set.Add(new TransactionTags
                {
                    TransactionId = transaction.Id,
                    TagId = tag.Id
                });
            }
            return set;
        }

        private string[] GetTags(IEnumerable<TransactionTags> transactionTags)
        {
            var tags = new List<string>();
            foreach(var tt in transactionTags)
            {
                tags.Add(tt.Tag.Name);
            }
            return tags.ToArray();
        }

        // TODO: Implement OR remove it if the issue of many-to-many relations is solved for EF Core in .Net Core 3+
        private IEnumerable<TransactionBO> GetTransactions(IEnumerable<TransactionTags> transactionTags)
        {
            var transactions = new List<TransactionBO>();
            //foreach (var tt in transactionTags)
            //{
            //    transactions.Add(new TransactionBO
            //    {
            //        Id = tt.TransactionId,
            //        Name = tt.Transaction.Name,
            //        Cost = tt.Transaction.Cost,
            //        Currency = new CurrencyBO
            //        {
            //            ISO_4217_Code = tt.Transaction.Currency.ISO_4217_Code,
            //            ISO_4217_Number = tt.Transaction.Currency.ISO_4217_Number,
            //            Name = tt.Transaction.Currency.Name
            //        },
            //        CreatedAt = tt.Transaction.CreatedAt,
            //        UpdatedAt = tt.Transaction.UpdatedAt,
            //        CommittedAt = tt.Transaction.CommittedAt,
            //        Tags = GetTags(tt.Transaction.TransactionTags)
            //    });
            //}
            return transactions;
        }
    }
}
