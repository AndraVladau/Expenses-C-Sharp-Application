namespace Expenses.Domain;

public class Invoice : Document, ICloneable
{
    public DateTime DueDate { get; set; }
    public List<Acquisition> Purchases { get; set; }
    public Category Category { get; set; }


    public object Clone()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return base.ToString() + " Due date: " + DueDate + " Category: " + Category; 
    }
}