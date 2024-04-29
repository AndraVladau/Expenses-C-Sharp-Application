using Expenses.Domain;

namespace Expenses.Repository;

public class DocumentsRepository : InFileRepository<string, Document>
{
    private void LoadFromFile()
    {
        using (StreamReader sr = new StreamReader(Filename))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                Document entitate = LoadOneEntity(s);
                Entities.Add(entitate.id, entitate);
            }
        }
    }
    
    private Document LoadOneEntity(string line)
    {
        string[] fields = line.Split(Separator);
        Document document = new Document()
        {
            id = fields[0],
            Name = fields[1],
            IssueDate = DateTime.Parse(fields[2])
        };
        return document;
    }
    
    public DocumentsRepository(string filename) : base(filename)
    {
        LoadFromFile();
    }

    public Document FindOne(string id)
    {
        return Entities[id];
    }
    
}