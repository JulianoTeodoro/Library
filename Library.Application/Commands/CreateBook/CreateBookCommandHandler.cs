using Library.Core.Entities;
using Library.Infra.Persistence.Context;
using MediatR;

namespace Library.Application.Commands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly LibraryContext _dbContext;

    public CreateBookCommandHandler(LibraryContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var newBook = new Book(request.Title, request.Author, request.ISBN, request.YearPublication);

        await _dbContext.Books.AddAsync(newBook);
        await _dbContext.SaveChangesAsync();
        
        return newBook.Id;
    }
}