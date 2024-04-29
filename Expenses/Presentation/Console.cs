using Expenses.Domain;
using Expenses.Service;

namespace Expenses.Presentation;

public class Console
{
    private ServiceApp _serviceApp;

    public Console(ServiceApp serviceApp)
    {
        _serviceApp = serviceApp;
    }

    public void Run()
    {
        while (true)
        {
            System.Console.WriteLine("Please select one of the options below:");
            System.Console.WriteLine("1. All documents issued in 2023.");
            System.Console.WriteLine("2. All bills due in the current month.");
            System.Console.WriteLine("3. All invoices with at least 3 products purchased.");
            System.Console.WriteLine("4. All purchases in category Utilities.");
            System.Console.WriteLine("5. The category of invoices that recorded the most expenses.");
            System.Console.WriteLine("E. Exit");
            ConsoleKeyInfo keyInfo = System.Console.ReadKey();
            char optiune = keyInfo.KeyChar;
            System.Console.WriteLine("");
            switch (optiune)
            {
                case '1' : AllDocumentsIssuedIn2023();
                    break;
                case '2': AllBillsDueInTheCurrentMonth();
                    break;
                case '3': AllInvoicesWithAtLeast3ProductsPurchased();
                    break;
                case '4': AllPurchasesInCategoryUtilities();
                    break;
                case '5': CategoryOfInvoicesWithTheMostExpenses();
                    break;
                case 'E' or 'e':
                    System.Console.WriteLine("GoodBye!");
                    return;
                default:
                    System.Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }

    private void AllDocumentsIssuedIn2023()
    {
        var lst = _serviceApp.AllDocumentsIssuedIn2023();
        if (!lst.Any())
        {
            System.Console.WriteLine("There is no document issued in 2023!");
            return;
        }
        foreach (var document in lst)
        {
            System.Console.WriteLine(document);
        }
    }

    private void AllBillsDueInTheCurrentMonth()
    {
        var lst = _serviceApp.AllBillsDueInTheCurrentMonth();
        if (!lst.Any())
        {
            System.Console.WriteLine("There is no bill due current month!");
            return;
        }
        foreach (var invoice in lst)
        {
            System.Console.WriteLine(invoice);
        }
    }
    
    private void AllInvoicesWithAtLeast3ProductsPurchased()
    {
        var lst = _serviceApp.AllInvoicesWithAtLeast3ProductsPurchased();
        if (!lst.Any())
        {
            System.Console.WriteLine("There is no invoice with at least 3 products pirchased!");
            return;
        }
        foreach (var invoice in lst)
        {
            System.Console.WriteLine(invoice);
        }
    }
    
    private void AllPurchasesInCategoryUtilities()
    {
        var lst = _serviceApp.AllPurchasesInCategoryUtilities();
        if (!lst.Any())
        {
            System.Console.WriteLine("There is no purchase in the Utilities category!");
            return;
        }
        foreach (var purchase in lst)
        {
            System.Console.WriteLine(purchase);
        }
    }
    
    private void CategoryOfInvoicesWithTheMostExpenses()
    {
        var result = _serviceApp.CategoryOfInvoicesWithTheMostExpenses();
        System.Console.WriteLine("The category of invoices that recorded the most expenses is " + result.Item1 + " with a total of " + result.Item2);
    }
}