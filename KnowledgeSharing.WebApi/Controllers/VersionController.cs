using KnowledgeSharing.Core.Version.Queries.GetVersion;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeSharing.WebApi.Controllers;

[Route("version")]
public class VersionController : MediatorController
{
    public VersionController(ISender mediator) : base(mediator) { }

    [HttpGet]
    public async Task<IActionResult> GetVersion()
    {
        App app = await Mediator.Send(new GetVersionQuery { EntryAssembly = GetType().Assembly });
        return Ok(app);
    }
}
