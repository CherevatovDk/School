namespace Pschool.BlazorWasm.IServices;

public interface IHttpClientService
{
    Task<T?> SendRequestAsync<T>(string url, HttpMethod? method = null, object? content = null);
}