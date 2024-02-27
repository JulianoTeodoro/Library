using MediatR;

namespace Library.Application.Commands.CreateBook;

public class CreateBookCommand : IRequest<int>
{
    public CreateBookCommand(string title, string author, string isbn, int yearPublication)
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
}