using Library.Core.Entities;
using Library.Core.Enums;
using Library.Infra.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Commands.CreateLoan;

public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, int>
{
    private readonly LibraryContext _dbContext;

    public CreateLoanCommandHandler(LibraryContext context)
    {
        _dbContext = context;
    }

    public async Task<int> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var userLoan = await _dbContext.Loans.Where(p => p.IdUser == request.IdUser)
                                                .Where(p => p.Status == StatusLoan.Delayed).ToListAsync();

        if (userLoan.Count > 0) throw new ArgumentException("Cliente ja possui emprestimo com atraso");

        var loan = new Loan(request.IdBook, request.IdUser, request.DaysLoan);

        await _dbContext.Loans.AddAsync(loan);
        await _dbContext.SaveChangesAsync();
        
        return loan.Id;
    }
    
}