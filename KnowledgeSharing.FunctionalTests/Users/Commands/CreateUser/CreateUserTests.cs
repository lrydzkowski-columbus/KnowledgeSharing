using FluentAssertions;
using KnowledgeSharing.Core.Users.Commands.CreateUser;
using KnowledgeSharing.Core.Users.Models;
using KnowledgeSharing.FunctionalTests.Common.Initializers;
using KnowledgeSharing.FunctionalTests.Common.Services;
using KnowledgeSharing.WebApi;
using System.Net;

namespace KnowledgeSharing.FunctionalTests.Users.Commands.CreateUser;

public class CreateUserTests : IClassFixture<WebApiFactory<Program>>
{
    public CreateUserTests(WebApiFactory<Program> webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
        RequestService = new RequestService();
    }

    public HttpClient HttpClient { get; }

    public RequestService RequestService { get; }

    public string UsersUrl => "/users";

    [Fact]
    public async Task CreateUser_CorrectData_ReturnsCreatedUser()
    {
        CreateUserCommand createUserCommand = new()
        {
            Login = "lrydzkowski",
            FirstName = "Łukasz",
            LastName = "Rydzkowski"
        };

        (HttpStatusCode createUserHttpStatusCode, UserDto? createdUser) =
            await RequestService.SendPostAsync<CreateUserCommand, UserDto>(
                UsersUrl,
                createUserCommand,
                HttpClient
            );
        (HttpStatusCode getUserHttpStatusCode, UserDto? userDto) = await RequestService.SendGetAsync<UserDto>(
            $"{UsersUrl}/{createdUser?.Id}",
            HttpClient
        );

        Assert.Equal(HttpStatusCode.OK, createUserHttpStatusCode);
        Assert.Equal(HttpStatusCode.OK, getUserHttpStatusCode);
        Assert.NotNull(userDto);
        userDto.Should()
            .BeEquivalentTo(new UserDto
            {
                Id = createdUser?.Id ?? 0,
                Login = createdUser!.Login,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                RoleNames = new List<string>()
            });
    }
}
