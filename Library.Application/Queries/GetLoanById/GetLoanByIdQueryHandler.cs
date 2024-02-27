using Library.Application.ViewModel;
using Library.Infra.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Queries;

public class GetLoanByIdQueryHandler : IRequestHandler<GetLoanByIdQuery, LoanViewModel>
{
    private readonly LibraryContext _dbContext;

    public GetLoanByIdQueryHandler(LibraryContext context)
    {
        _dbContext = context;
    }

    public async Task<LoanViewModel> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
    {
        var loan = await _dbContext.Loans.Where(p => p.Id == request.Id)
            .Include(p => p.User)
            .Include(p => p.Book)
            .Select(p => new LoanViewModel(p.Book.Title, p.User.Name, p.StartLoan, p.DaysLoan, p.Status))
            .SingleOrDefaultAsync();
    
        
        return loan;
    }
}