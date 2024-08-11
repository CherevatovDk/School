using AutoMapper;
using Pschool.Core.DTOs;
using Pschool.Core.Interface;
using Pschool.Infrastructure.IRepositories;
using Pschool.Infrastructure.Models;

namespace Pschool.Core.Services;

public class ParentService(IRepository<Parent> repositoryParent, IMapper mapper) : IParentService
{
    private readonly IRepository<Parent> _repositoryParent = repositoryParent;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ParentDto>> GetParentsAsync()
    {
        var parents =await _repositoryParent.GetAllAsync();
        return  _mapper.Map<IEnumerable<ParentDto>>(parents);
    }

    public async Task<ParentDto> GetParentsByIdAsync(int id)
    {
        var parent = await _repositoryParent.GetByIdAsync(id);
        return _mapper.Map<ParentDto>(parent);
    }

    public async Task<ParentDto> AddParentAsync(ParentDto parentDto)
    {
        var existParent = await _repositoryParent.GetByEmailAsync(parentDto.Email);
        if (existParent != null)
        {
            throw new InvalidOperationException("A parent with this email already exists.");
        }
        var parent = _mapper.Map<Parent>(parentDto);
        await _repositoryParent.AddAsync(parent);
        return _mapper.Map<ParentDto>(parent);
    }

    public async Task<ParentDto?> UpdateParentAsync(int id, ParentDto parentDto)
    {
        var parent =await _repositoryParent.GetByIdAsync(id);
        if (parent == null) return null;
        _mapper.Map(parentDto, parent);
        await _repositoryParent.UpdateAsync(parent);
        return _mapper.Map<ParentDto>(parent);
    }

    public async Task<bool> DeleteParentAsync(int id)
    {
        var parent =await _repositoryParent.GetByIdAsync(id);
        if (parent == null) return false;
         await _repositoryParent.DeleteAsync(parent);
        return true;

    }
}