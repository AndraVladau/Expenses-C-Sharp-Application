using Expenses.Domain;

namespace Expenses.Repository;

public class InvoicesRepository : InFileRepository<string, Invoice>
{
    private DocumentsRepository _documentsRepository;
    
    private void LoadFromFile()
    {
        using (StreamReader sr = new StreamReader(Filename))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                Invoice entitate = LoadOneEntity(s);
                Entities.Add(entitate.id, entitate);
            }
        }
    }
    
    private Invoice LoadOneEntity(string line)
    {
        string[] fields = line.Split(Separator);
        Document document = _documentsRepository.FindOne(fields[0]);
        Invoice invoice = new Invoice()
        {
            id = fields[0],
            DueDate = DateTime.Parse(fields[1]),
            Category = (Category)Enum.Parse(typeof(Category), fields[2]),
            Purchases = new List<Acquisition>(),
            IssueDate = document.IssueDate,
            Name = document.Name
        };
        return invoice;
    }
    public InvoicesRepository(string filename, DocumentsRepository documentsRepository) : base(filename)
    {
        _documentsRepository = documentsRepository;
        LoadFromFile();
    }
    
    public Invoice FindOne(string id)
    {
        return Entities[id];
    }

    public void AddPurchasesToInvoices(Acquisition acquisition)
    {
        Entities[acquisition.PurchaseInvoice.id].Purchases.Add(acquisition);
    }

    
    
}