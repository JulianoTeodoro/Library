using Library.Application.ViewModel;
using MediatR;

namespace Library.Application.Queries.GetLoanByIdUser;

public class GetLoansByIdUserQuery : IRequest<List<LoanViewModel>>
{
    public GetLoansByIdUserQuery(int idUser)
    {
        IdUser = idUser;
    }
    public int IdUser { get; private set; }
}