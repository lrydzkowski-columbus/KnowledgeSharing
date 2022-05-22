using KnowledgeSharing.Core.Users.Commands.CreateUser;
using KnowledgeSharing.Core.Users.Queries.GetUser;
using KnowledgeSharing.Persistence.Db.Users.Commands.CreateUser;
using KnowledgeSharing.Persistence.Db.Users.Queries.GetUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KnowledgeSharing.Persistence.Db;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceDbService(
        this IServiceCollection services, string dbConnectionString)
    {
        services.AddRepositories();
        services.AddDbContext<AppDbContext>(
            opts => opts.UseNpgsql(dbConnectionString)
        );
        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGetUserRepository, GetUserRepository>();
        services.AddScoped<ICreateUserRepository, CreateUserRepository>();
    }
}
