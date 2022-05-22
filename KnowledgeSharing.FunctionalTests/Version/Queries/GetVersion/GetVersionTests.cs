using KnowledgeSharing.Core.Version.Queries.GetVersion;
using KnowledgeSharing.FunctionalTests.Common.Initializers;
using KnowledgeSharing.WebApi;
using System.Text.Json;

namespace KnowledgeSharing.FunctionalTests.Version.Queries.GetVersion;

public class GetVersionTests : IClassFixture<WebApiFactory<Program>>
{
    public GetVersionTests(WebApiFactory<Program> webApplicationFactory)
    {
        HttpClient = webApplicationFactory.CreateClient();
    }

    public HttpClient HttpClient { get; }

    [Fact]
    public async Task GetVersion_CorrectData_ReturnsCorrectVersion()
    {
        string semVerRegex = new SemVerRegex().Get();

        JsonSerializerOptions jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };

        var httpResponse = await HttpClient.GetAsync("/version");

        httpResponse.EnsureSuccessStatusCode();
        var responseContent = await httpResponse.Content.ReadAsStringAsync();
        var parsedResponse = JsonSerializer.Deserialize<App>(
            responseContent, jsonSerializerOptions
        );
        Assert.Matches(semVerRegex, parsedResponse?.Version ?? "");
    }
}
