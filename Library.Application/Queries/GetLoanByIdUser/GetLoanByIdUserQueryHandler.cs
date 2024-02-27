using Library.Application.ViewModel;
using Library.Infra.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Queries.GetLoanByIdUser;

public class GetLoanByIdUserQueryHandler : IRequestHandler<GetLoansByIdUserQuery, List<LoanViewModel>>
{
    private readonly LibraryContext _dbContext;

    public GetLoanByIdUserQueryHandler(LibraryContext context)
    {
        _dbContext = context;
    }

    public async Task<List<LoanViewModel>> Handle(GetLoansByIdUserQuery request, CancellationToken cancellationToken)
    {
        var loans = await _dbContext.Loans
            .Where(p => p.IdUser == request.IdUser)
            .Include(p => p.User)
            .Include(p => p.Book)
            .Select(p => new LoanViewModel(p.Book.Title, p.User.Name, p.StartLoan, p.DaysLoan, p.Status))
            .ToListAsync();

        return loans;
    }
}