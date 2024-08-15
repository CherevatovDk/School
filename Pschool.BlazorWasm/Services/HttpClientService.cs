using System.Net.Http.Json;
using Pschool.BlazorWasm.IServices;

namespace Pschool.BlazorWasm.Services;

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<HttpClientService> _logger;

    public HttpClientService(HttpClient httpClient, ILogger<HttpClientService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<T?> SendRequestAsync<T>(string url, HttpMethod method = null, object content = null)
    {
        method ??= HttpMethod.Get;
        try
        {
            HttpResponseMessage response;
            if (method == HttpMethod.Get)
            {
                response = await _httpClient.GetAsync(url);
            }
            else if (method == HttpMethod.Post)
            {
                response = await _httpClient.PostAsJsonAsync(url, content);
            }
            else if (method == HttpMethod.Put)
            {
                response = await _httpClient.PutAsJsonAsync(url, content);
            }
            else if (method == HttpMethod.Delete)
            {
                response = await _httpClient.DeleteAsync(url);
            }
            else
            {
                throw new NotSupportedException($"HTTP method {method} is not supported.");
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error handling request to {url}");
            throw;
        }
    }
}