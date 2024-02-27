namespace Library.Core.Entities;

public class Book : BaseEntity
{
    public Book(string title, string author, string iSBN, int yearPublication)
    {
        Title = title;
        Author = author;
        ISBN = iSBN;
        YearPublication = yearPublication;
    }
    
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int YearPublication { get; private set; }
    
    public List<Loan> BooksLoan { get; private set; }
    
    
}