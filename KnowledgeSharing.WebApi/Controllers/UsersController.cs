using KnowledgeSharing.Core.Users.Commands.CreateUser;
using KnowledgeSharing.Core.Users.Models;
using KnowledgeSharing.Core.Users.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeSharing.WebApi.Controllers;

[Route("users")]
public class UsersController : MediatorController
{
    public UsersController(ISender mediator) : base(mediator) { }

    [HttpGet, Route("{userId}")]
    public async Task<IActionResult> GetUser(int userId)
    {
        UserDto? user = await Mediator.Send(new GetUserQuery { UserId = userId });
        return user == null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand createUserCommand)
    {
        UserDto createdUser = await Mediator.Send(createUserCommand);
        return Ok(createdUser);
    }
}
