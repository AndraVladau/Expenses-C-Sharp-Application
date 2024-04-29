namespace Expenses.Domain;

public class Document : Entity<string>, ICloneable
{
    public string Name { get; set; }
    public DateTime IssueDate { get; set; }

    public object Clone()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return base.ToString() + Name + " Issue Date: " + IssueDate;
    }
}