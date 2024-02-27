using Library.Application.ViewModel;
using Library.Core.Entities;
using MediatR;

namespace Library.Application.Queries.GetBookById;

public class GetBookByIdQuery : IRequest<BookViewModel>
{
    public GetBookByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; private set; }
}