namespace Expenses.Domain;

public class Acquisition : Entity<string>, ICloneable
{
    public string Product { get; set; }
    public int Amount { get; set; }
    public double Price { get; set; }
    public Invoice PurchaseInvoice { get; set; }
    

    public object Clone()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return base.ToString() + Product + " x " + Amount + " Price: " + Price + " Invoice " +
               PurchaseInvoice;
    }
}