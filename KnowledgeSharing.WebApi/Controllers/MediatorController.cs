using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeSharing.WebApi.Controllers;

[ApiController]
public class MediatorController : ControllerBase
{
    protected ISender Mediator { get; }

    public MediatorController(ISender mediator)
    {
        Mediator = mediator;
    }
}
