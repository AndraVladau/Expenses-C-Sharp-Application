using Expenses.Domain;

namespace Expenses.Repository;

public interface IRepository<ID, E> where E : Entity<ID>
{
    IEnumerable<E> FindAll();
}