using KnowledgeSharing.Core.Users.Models;
using MediatR;

namespace KnowledgeSharing.Core.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<UserDto>
{
    public string Login { get; init; } = "";

    public string FirstName { get; init; } = "";

    public string LastName { get; init; } = "";
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    public CreateUserCommandHandler(ICreateUserRepository createUserRepository)
    {
        CreateUserRepository = createUserRepository;
    }

    private ICreateUserRepository CreateUserRepository { get; }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        UserDto user = await CreateUserRepository.CreateUserAsync(request);
        return user;
    }
}
