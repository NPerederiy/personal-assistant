using FinancialControl.DAL.EF;
using FinancialControl.DAL.Entities;
using FinancialControl.DAL.Repositories.Abstractions;

namespace FinancialControl.DAL.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<User> UserRepository { get; }
        public IRepository<Category> CategoryRepository { get; }
        public IRepository<Transaction> TransactionRepository { get; }
        public IRepository<Currency> CurrencyRepository { get; }
        public IRepository<Tag> TagRepository { get; }

        public UnitOfWork(FinancialControlDbContext context)
        {
            UserRepository = new GenericRepository<User, FinancialControlDbContext>(context);
            CategoryRepository = new GenericRepository<Category, FinancialControlDbContext>(context);
            TransactionRepository = new GenericRepository<Transaction, FinancialControlDbContext>(context);
            CurrencyRepository = new GenericRepository<Currency, FinancialControlDbContext>(context);
            TagRepository = new GenericRepository<Tag, FinancialControlDbContext>(context);
        }
    }
}
