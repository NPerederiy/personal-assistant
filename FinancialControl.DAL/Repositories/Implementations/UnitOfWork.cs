using FinancialControl.DAL.EF;
using FinancialControl.DAL.Entities;
using FinancialControl.DAL.Repositories.Abstractions;

namespace FinancialControl.DAL.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<User> UserRepository { get; }
        public IRepository<Operation> OperationRepository { get; }
        public IRepository<Group> GroupRepository { get; }
        public IRepository<Category> CategoryRepository { get; }

        public UnitOfWork(FinancialControlDbContext context)
        {
            UserRepository = new GenericRepository<User, FinancialControlDbContext>(context);
            OperationRepository = new GenericRepository<Operation, FinancialControlDbContext>(context);
            GroupRepository = new GenericRepository<Group, FinancialControlDbContext>(context);
            CategoryRepository = new GenericRepository<Category, FinancialControlDbContext>(context);
        }
    }
}
