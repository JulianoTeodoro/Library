using MediatR;

namespace Library.Application.Commands.LoanDevolver;

public class LoanDevolverCommand : IRequest<string>
{
    public LoanDevolverCommand(int id)
    {
        Id = id;
    }
    public int Id { get; private set; }
}