using AutoMapper;
using Pschool.Core.DTOs;
using Pschool.Core.Interface;
using Pschool.Infrastructure.IRepositories;
using Pschool.Infrastructure.Models;

namespace Pschool.Core.Services;

public class ParentService(IRepository<Parent> repositoryParent, IMapper mapper) : IParentService
{
    public async Task<IEnumerable<ParentDto>?> GetParentsAsync()
    {
        var parents = await repositoryParent.GetAllAsync();
        return mapper.Map<IEnumerable<ParentDto>>(parents);
    }

    public async Task<ParentDto?> GetParentsByIdAsync(int id)
    {
        var parent = await repositoryParent.GetByIdAsync(id);
        return mapper.Map<ParentDto>(parent);
    }

    public async Task<ParentDto?> AddParentAsync(ParentDto parentDto)
    {
        var existParent = await repositoryParent.GetByEmailAsync(parentDto.Email);
        if (existParent != null)
        {
            throw new InvalidOperationException("A parent with this email already exists."); //TODO move to constants
        }

        var parent = mapper.Map<Parent>(parentDto);
        await repositoryParent.AddAsync(parent);
        return mapper.Map<ParentDto>(parent);
    }

    public async Task<ParentDto?> UpdateParentAsync(int id, ParentDto parentDto)
    {
        var parent = await repositoryParent.GetByIdAsync(id);
        if (parent == null) return null; //TODO throw invalid exception with message 
        mapper.Map(parentDto, parent);
        await repositoryParent.UpdateAsync(parent);
        return mapper.Map<ParentDto>(parent);
    }

    public async Task<bool> DeleteParentAsync(int id)
    {
        var parent = await repositoryParent.GetByIdAsync(id);
        if (parent == null) return false;// TODO throw invalid exception with message 
        await repositoryParent.DeleteAsync(parent);
        return true;
    }
}