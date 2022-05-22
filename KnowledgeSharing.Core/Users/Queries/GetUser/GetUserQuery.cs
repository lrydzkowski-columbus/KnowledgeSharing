using KnowledgeSharing.Core.Users.Models;
using MediatR;

namespace KnowledgeSharing.Core.Users.Queries.GetUser;

public class GetUserQuery : IRequest<UserDto?>
{
    public int UserId { get; init; }
}

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto?>
{
    public GetUserQueryHandler(IGetUserRepository repository)
    {
        Repository = repository;
    }

    private IGetUserRepository Repository { get; }

    public async Task<UserDto?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await Repository.GetUserAsync(request.UserId);
    }
}
