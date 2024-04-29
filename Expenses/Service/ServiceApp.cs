using System.Formats.Asn1;
using Expenses.Domain;
using Expenses.Repository;

namespace Expenses.Service;

public class ServiceApp
{
    private IRepository<string, Document> _documentsRepository;
    private IRepository<string, Invoice> _invoicesRepository;
    private IRepository<string, Acquisition> _acquisitionsRepository;

    public ServiceApp(DocumentsRepository documentsRepository, InvoicesRepository invoicesRepository, AcquisitionsRepository acquisitionsRepository)
    {
        _documentsRepository = documentsRepository;
        _invoicesRepository = invoicesRepository;
        _acquisitionsRepository = acquisitionsRepository;
    }

    public IEnumerable<Invoice> GetAllFacturi()
    {
        return _invoicesRepository.FindAll();
    }
    public IEnumerable<Document> GetAllDocumente()
    {
        return _documentsRepository.FindAll();
    }
    public IEnumerable<Acquisition> GetAllAchizitii()
    {
        return _acquisitionsRepository.FindAll();
    }

    public IEnumerable<Document> AllDocumentsIssuedIn2023()
    {
        var documents = GetAllDocumente();
        var query = from document in documents
            where document.IssueDate.Year.Equals(2023)
            select document;
        return query;
    }

    public IEnumerable<Invoice> AllBillsDueInTheCurrentMonth()
    {
        var invoices = GetAllFacturi();
        var query = from invoice in invoices
            where invoice.DueDate.Month.Equals(DateTime.Now.Month)
            select invoice;
        return query;
    }

    public IEnumerable<Invoice> AllInvoicesWithAtLeast3ProductsPurchased()
    {
        var invoices = GetAllFacturi();
        var query = from invoice in invoices
            where (from purchase in invoice.Purchases
                    select purchase.Amount).Sum() >= 3
            select invoice;
        return query;
    }

    public IEnumerable<Acquisition> AllPurchasesInCategoryUtilities()
    {
        var invoices = GetAllFacturi();
        var purchases = GetAllAchizitii();
        var query = from ach in purchases
            join f in invoices on ach.PurchaseInvoice.id equals f.id
            where f.Category.Equals(Category.Utilities)
            select ach;
        return query;
    }

    public Tuple<Category, Double> CategoryOfInvoicesWithTheMostExpenses()
    {
        var invoices = GetAllFacturi();
        var purchases = GetAllAchizitii();
        var query = from ach in purchases
            join fact in invoices on ach.PurchaseInvoice.id equals fact.id
            group ach.Amount * ach.Price by fact.Category
            into grupCategorii
            select new
            {
                Categorie = grupCategorii.Key,
                Suma = grupCategorii.Sum()
            };

        var queryMax = (from pair in query
            orderby pair.Suma descending
            select pair).FirstOrDefault();
        return new Tuple<Category, double>(queryMax.Categorie, queryMax.Suma);
    }
}