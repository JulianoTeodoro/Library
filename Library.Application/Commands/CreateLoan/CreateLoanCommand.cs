using MediatR;

namespace Library.Application.Commands.CreateLoan;

public class CreateLoanCommand : IRequest<int>
{
    public CreateLoanCommand(int idBook, int idUser, int daysLoan)
    {
        IdBook = idBook;
        IdUser = idUser;
        DaysLoan = daysLoan;
    }
    public int IdBook { get; private set; }
    public int IdUser { get; private set; }
    public int DaysLoan { get; private set; }
}