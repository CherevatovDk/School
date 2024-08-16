using Pschool.Core.DTOs;

namespace Pschool.Core.Interface;

public interface IParentService
{
    Task<IEnumerable<ParentDto>?> GetParentsAsync();
    Task<ParentDto?> GetParentsByIdAsync(int id);
    Task<ParentDto?> AddParentAsync(ParentDto parentDto);
    Task<ParentDto?> UpdateParentAsync(int id, ParentDto parentDto);
    Task<bool> DeleteParentAsync(int id);

}