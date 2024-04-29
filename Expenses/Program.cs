// See https://aka.ms/new-console-template for more information

// Console.WriteLine("Hello, World!");

using Expenses.Domain;
using Expenses.Presentation;
using Expenses.Repository;
using Expenses.Service;
using Console = Expenses.Presentation.Console;

static void main()
{
    DocumentsRepository documentsRepository = new DocumentsRepository("C:\\Users\\aivla\\Desktop\\Andra\\College\\Anul II\\Semestrul I\\Metode avansate de programare\\Laboratoare\\Rezolvari\\Expenses\\Expenses\\Data\\Documents.txt");
    InvoicesRepository invoicesRepository = new InvoicesRepository("C:\\Users\\aivla\\Desktop\\Andra\\College\\Anul II\\Semestrul I\\Metode avansate de programare\\Laboratoare\\Rezolvari\\Expenses\\Expenses\\Data\\Invoices.txt", documentsRepository);
    AcquisitionsRepository acquisitionsRepository = new AcquisitionsRepository("C:\\Users\\aivla\\Desktop\\Andra\\College\\Anul II\\Semestrul I\\Metode avansate de programare\\Laboratoare\\Rezolvari\\Expenses\\Expenses\\Data\\Acquisitions.txt", invoicesRepository);
    ServiceApp serviceApp = new ServiceApp(documentsRepository, invoicesRepository, acquisitionsRepository);
    Console console = new Console(serviceApp);
    console.Run();
}

main();