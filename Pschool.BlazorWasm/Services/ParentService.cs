using System.Net.Http.Json;
using Pschool.Core.DTOs;

namespace Pschool.BlazorWasm.Services;

public class ParentService : IParentService
{
    private readonly HttpClient _httpClient;

    public ParentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    

    public async Task<List<ParentDto>?> GetAllParentsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<ParentDto>>("/parent/all");
    }

  

    public async Task<ParentDto?> GetParentByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<ParentDto>($"parent/{id}");
    }

    public async Task<ParentDto?> AddParentAsync(ParentDto parentDto)
    {
        var response = await _httpClient.PostAsJsonAsync("parent/add", parentDto);
        return await response.Content.ReadFromJsonAsync<ParentDto>();
    }

    public async Task<ParentDto?> UpdateParentAsync(int id, ParentDto parentDto)
    {
        var response = await _httpClient.PutAsJsonAsync($"/parent/{id}", parentDto);
        return await response.Content.ReadFromJsonAsync<ParentDto>();
    }

    public async Task<bool> DeleteParentAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"/parent/{id}");
        return response.IsSuccessStatusCode;
    }
}