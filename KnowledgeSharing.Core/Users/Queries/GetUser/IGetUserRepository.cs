using KnowledgeSharing.Core.Users.Models;

namespace KnowledgeSharing.Core.Users.Queries.GetUser;

public interface IGetUserRepository
{
    public Task<UserDto?> GetUserAsync(int userId);
}
