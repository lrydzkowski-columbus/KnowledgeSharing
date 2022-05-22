using System.Net;
using System.Text;
using System.Text.Json;

namespace KnowledgeSharing.FunctionalTests.Common.Services;

public class RequestService
{
    public async Task<(HttpStatusCode, TResp?)> SendPostAsync<TReq, TResp>(
        string url, TReq request, HttpClient httpClient) where TResp : class
    {
        var requestContent = new StringContent(
            JsonSerializer.Serialize(request), Encoding.UTF8, "application/json"
        );
        HttpRequestMessage requestMessage = new(HttpMethod.Post, url)
        {
            Content = requestContent
        };
        HttpResponseMessage httpResponse = await httpClient.SendAsync(requestMessage);
        string responseContent = await httpResponse.Content.ReadAsStringAsync();
        TResp? response = JsonSerializer.Deserialize<TResp>(
            responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        return (httpResponse.StatusCode, response);
    }

    public async Task<(HttpStatusCode, TResp?)> SendGetAsync<TResp>(
        string url, HttpClient httpClient) where TResp : class
    {
        return await SendRequestWithoutBodyAsync<TResp>(HttpMethod.Get, url, httpClient);
    }

    private async Task<(HttpStatusCode, TResp?)> SendRequestWithoutBodyAsync<TResp>(
        HttpMethod httpMethod, string url, HttpClient httpClient) where TResp : class
    {
        HttpRequestMessage requestMessage = new(httpMethod, url);
        HttpResponseMessage httpResponse = await httpClient.SendAsync(requestMessage);
        string responseContent = await httpResponse.Content.ReadAsStringAsync();
        TResp? response = JsonSerializer.Deserialize<TResp>(
            responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        return (httpResponse.StatusCode, response);
    }
}
