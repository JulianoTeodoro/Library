using Library.Application.ViewModel;
using Library.Core.Entities;
using Library.Infra.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Queries.GetBookById;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookViewModel>
{
    private readonly LibraryContext _dbContext;

    public GetBookByIdQueryHandler(LibraryContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<BookViewModel> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _dbContext.Books.Where(p => p.Id == request.Id).Select(p => new BookViewModel(p.Title, p.Author, p.ISBN)).SingleOrDefaultAsync();

        return book;
    }
}