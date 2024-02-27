using Library.Infra.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Commands.LoanDevolver;

public class LoanDevolverCommandHandler : IRequestHandler<LoanDevolverCommand, string>
{
    private readonly LibraryContext _dbContext;

    public LoanDevolverCommandHandler(LibraryContext context)
    {
        _dbContext = context;
    }
    public async Task<string> Handle(LoanDevolverCommand request, CancellationToken cancellationToken)
    {
        var loan = await _dbContext.Loans.Where(p => p.Id == request.Id).SingleOrDefaultAsync();

        var finishedLoan = loan.FinishedLoan();
        await _dbContext.SaveChangesAsync();
        return finishedLoan;
    }
}