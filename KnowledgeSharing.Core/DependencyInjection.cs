using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KnowledgeSharing.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
