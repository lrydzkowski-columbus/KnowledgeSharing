using KnowledgeSharing.Core.Users.Models;

namespace KnowledgeSharing.Core.Users.Commands.CreateUser;

public interface ICreateUserRepository
{
    public Task<UserDto> CreateUserAsync(CreateUserCommand createUserCommand);
}
