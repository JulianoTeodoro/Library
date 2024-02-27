namespace Library.Application.ViewModel;

public class BookViewModel
{
    public BookViewModel(string title, string author, string iSBN)
    {
        Title = title;
        Author = author;
        ISBN = iSBN;
    }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
}