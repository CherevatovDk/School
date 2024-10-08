using Pschool.Core.DTOs;

namespace Pschool.BlazorWasm.IServices;

public interface IParentService
{
    Task<List<ParentDto>?> GetAllParentsAsync();
    Task<ParentDto?> GetParentByIdAsync(int id);
    Task<ParentDto?> AddParentAsync(ParentDto? parentDto);
    Task<ParentDto?> UpdateParentAsync(int id, ParentDto? parentDto);
    Task<bool> DeleteParentAsync(int id);
}