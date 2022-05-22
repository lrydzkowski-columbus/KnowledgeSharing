using FluentAssertions;
using KnowledgeSharing.Core.Users.Models;
using KnowledgeSharing.FunctionalTests.Common.Initializers;
using KnowledgeSharing.FunctionalTests.Common.Services;
using KnowledgeSharing.WebApi;
using System.Net;

namespace KnowledgeSharing.FunctionalTests.Users.Queries.GetUser;

public class GetUserTests : IClassFixture<WebApiFactory<Program>>
{
    public GetUserTests(WebApiFactory<Program> webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
        RequestService = new RequestService();
    }

    public HttpClient HttpClient { get; }

    public RequestService RequestService { get; }

    public string UsersUrl => "/users";

    [Fact]
    public async Task GetUser_NotExistingUserId_ReturnsNotFound()
    {
        int userId = 0;

        (HttpStatusCode getUserHttpStatusCode, _) = await RequestService.SendGetAsync<UserDto>(
            $"{UsersUrl}/{userId}",
            HttpClient
        );

        Assert.Equal(HttpStatusCode.NotFound, getUserHttpStatusCode);
    }

    [Fact]
    public async Task GetUser_ExistingUserId_ReturnsUser()
    {
        int userId = 1;

        (HttpStatusCode getUserHttpStatusCode, UserDto? userDto) = await RequestService.SendGetAsync<UserDto>(
            $"{UsersUrl}/{userId}",
            HttpClient
        );

        Assert.Equal(HttpStatusCode.OK, getUserHttpStatusCode);
        Assert.NotNull(userDto);
        userDto.Should()
            .BeEquivalentTo(new UserDto
            {
                Id = userId,
                Login = "lrydzkowski",
                FirstName = "Łukasz",
                LastName = "Rydzkowski",
                RoleNames = new List<string> { "admin" }
            });
    }
}
