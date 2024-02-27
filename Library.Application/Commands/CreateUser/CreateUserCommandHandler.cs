using Library.Application.Commands.CreateBook;
using Library.Core.Entities;
using Library.Infra.Persistence.Context;
using MediatR;

namespace Library.Application.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly LibraryContext _dbContext;

    public CreateUserCommandHandler(LibraryContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Email);

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user.Id;
    }
}