using FinancialControl.DAL.Entities;

namespace FinancialControl.DAL.Repositories.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        IRepository<Transaction> TransactionRepository { get; }
        IRepository<Currency> CurrencyRepository { get; }
        IRepository<Tag> TagRepository { get; }
    }
}
