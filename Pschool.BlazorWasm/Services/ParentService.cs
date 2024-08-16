using Pschool.BlazorWasm.IServices;
using Pschool.Core.DTOs;

namespace Pschool.BlazorWasm.Services;

public class ParentService : IParentService
{
    private readonly IHttpClientService _httpClientService;

    public ParentService(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    public async Task<List<ParentDto>?> GetAllParentsAsync()
    {
        return await _httpClientService.SendRequestAsync<List<ParentDto>>("parent/all");
    }

    public async Task<ParentDto?> GetParentByIdAsync(int id)
    {
        return await _httpClientService.SendRequestAsync<ParentDto>($"parent/{id}");
    }

    public async Task<ParentDto?> AddParentAsync(ParentDto? parentDto)
    {
        return await _httpClientService.SendRequestAsync<ParentDto>("parent/add", HttpMethod.Post, parentDto);
    }

    public async Task<ParentDto?> UpdateParentAsync(int id, ParentDto? parentDto)
    {
        return await _httpClientService.SendRequestAsync<ParentDto>($"parent/{id}", HttpMethod.Put, parentDto);
    }

    public async Task<bool> DeleteParentAsync(int id)
    {
        var response = await _httpClientService.SendRequestAsync<object>($"parent/{id}", HttpMethod.Delete);
        return response != null;
    }
}