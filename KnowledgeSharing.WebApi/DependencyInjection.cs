using KnowledgeSharing.Core;
using KnowledgeSharing.Persistence.Db;

namespace KnowledgeSharing.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCoreServices();
        services.AddPersistenceDbService(configuration["DbConnectionString"]);
        return services;
    }
}
