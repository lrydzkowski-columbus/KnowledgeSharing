using MediatR;
using System.Reflection;

namespace KnowledgeSharing.Core.Version.Queries.GetVersion;

public class GetVersionQuery : IRequest<App>
{
    public Assembly? EntryAssembly { get; init; }
}

public class GetVersionQueryHandler : IRequestHandler<GetVersionQuery, App>
{
    public Task<App> Handle(GetVersionQuery request, CancellationToken cancellationToken)
    {
        string? version = request.EntryAssembly?
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.
            InformationalVersion;
        return Task.FromResult(new App { Version = version });
    }
}
