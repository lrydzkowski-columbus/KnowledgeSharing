using KnowledgeSharing.Core.Users.Models;
using KnowledgeSharing.Core.Users.Queries.GetUser;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeSharing.Persistence.Db.Users.Queries.GetUser;

internal class GetUserRepository : IGetUserRepository
{
    public GetUserRepository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    private AppDbContext DbContext { get; }

    public async Task<UserDto?> GetUserAsync(int userId)
    {
        UserDto? user = await DbContext.Users
            .AsNoTracking()
            .Where(user => user.Id == userId)
            .Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                RoleNames = user.Roles.Select(role => role.Name).ToList()
            })
            .FirstOrDefaultAsync();
        return user;
    }
}
