using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace KnowledgeSharing.Persistence.Db;

internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var connectionString = GetConnectionStringFromUserSecrets();
        DbContextOptionsBuilder<AppDbContext> builder = new();
        builder.UseNpgsql(
            connectionString,
            x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
        );
        return new AppDbContext(builder.Options);
    }

    private string GetConnectionStringFromUserSecrets()
    {
        var config = new ConfigurationBuilder().AddUserSecrets<AppDbContext>().Build();
        var secretProvider = config.Providers.First();
        if (!secretProvider.TryGet("DbConnectionString", out var connectionString)
            || connectionString == null
            || connectionString.Length == 0)
        {
            throw new Exception("There is no DbConnectionString in user secrets.");
        }
        return connectionString;
    }
}