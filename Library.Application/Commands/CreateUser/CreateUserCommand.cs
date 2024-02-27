using MediatR;

namespace Library.Application.Commands.CreateUser;

public class CreateUserCommand : IRequest<int>
{
    public CreateUserCommand(string name, string email)
    {
        Name = name;
        Email = email;
    }
    public string Name { get; private set; }
    public string Email { get; private set; }
}