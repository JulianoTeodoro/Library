using Library.Application.ViewModel;
using MediatR;

namespace Library.Application.Queries;

public class GetLoanByIdQuery : IRequest<LoanViewModel>
{
    public GetLoanByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; private set; }
}