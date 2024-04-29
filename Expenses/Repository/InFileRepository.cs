using System.Runtime.CompilerServices;
using Expenses.Domain;

namespace Expenses.Repository;

public class InFileRepository<ID, E> : InMemoryRepository<ID, E> where E : Entity<ID>
{
    protected string Filename;
    
    protected char Separator = ',';
    
    public InFileRepository(string filename)
    {
        Filename = filename;
    }
}