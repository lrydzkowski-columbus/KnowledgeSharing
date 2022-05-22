using KnowledgeSharing.Core.Users.Commands.CreateUser;
using KnowledgeSharing.Core.Users.Models;
using KnowledgeSharing.Persistence.Db.Common.Entities;

namespace KnowledgeSharing.Persistence.Db.Users.Commands.CreateUser;

internal class CreateUserRepository : ICreateUserRepository
{
    public CreateUserRepository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    private AppDbContext DbContext { get; }

    public async Task<UserDto> CreateUserAsync(CreateUserCommand createUserCommand)
    {
        UserEntity userEntity = new()
        {
            Login = createUserCommand.Login,
            FirstName = createUserCommand.FirstName,
            LastName = createUserCommand.LastName
        };
        await DbContext.Users.AddAsync(userEntity);
        await DbContext.SaveChangesAsync();
        return new UserDto()
        {
            Id = userEntity.Id,
            Login = userEntity.Login,
            FirstName = userEntity.FirstName,
            LastName = userEntity.LastName
        };
    }
}
