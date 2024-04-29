using Expenses.Domain;

namespace Expenses.Repository;

public class InMemoryRepository<ID, E> : IRepository<ID, E> where E : Entity<ID>
{
    protected IDictionary<ID, E> Entities;
    
    public InMemoryRepository()
    {
        Entities = new Dictionary<ID, E>();
    }

    public IEnumerable<E> FindAll()
    {
        return Entities.Values.ToList();
    }
}