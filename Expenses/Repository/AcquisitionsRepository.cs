using Expenses.Domain;

namespace Expenses.Repository;

public class AcquisitionsRepository : InFileRepository<string, Acquisition>
{
    private InvoicesRepository _invoicesRepository;
    private void LoadFromFile()
    {
        using (StreamReader sr = new StreamReader(Filename))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                Acquisition entitate = LoadOneEntity(s);
                Entities.Add(entitate.id, entitate);
            }
        }
    }
    
    private Acquisition LoadOneEntity(string line)
    {
        string[] fields = line.Split(',');
        
        Acquisition acquisition = new Acquisition()
        {
            id = fields[0],
            Product = fields[1],
            Amount = int.Parse(fields[2]),
            Price = double.Parse(fields[3]),
            PurchaseInvoice = _invoicesRepository.FindOne(fields[4])
        };
        return acquisition;
    }
    
    public AcquisitionsRepository(string filename, InvoicesRepository invoicesRepository) : base(filename)
    {
        _invoicesRepository = invoicesRepository;
        LoadFromFile();
        AddPurchasesToInvoices();
    }

    private void AddPurchasesToInvoices()
    {
        foreach (var keyValuePair in Entities)
        {
            _invoicesRepository.AddPurchasesToInvoices(keyValuePair.Value);
        }
    }
}