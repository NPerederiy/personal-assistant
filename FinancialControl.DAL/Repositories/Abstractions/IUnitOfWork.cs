using FinancialControl.DAL.Entities;

namespace FinancialControl.DAL.Repositories.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Operation> OperationRepository { get; }
        IRepository<Group> GroupRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        IRepository<User> UserRepository { get; }
    }
}
