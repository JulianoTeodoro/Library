namespace Library.Core.Entities;

public class Book : BaseEntity
{
    public Book(string title, string author, string isbn, int yearPublication)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        YearPublication = yearPublication;
    }
    
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int YearPublication { get; private set; }
    
    public List<Loan> BooksLoan { get; private set; }
    
    
}