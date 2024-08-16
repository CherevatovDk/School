using System.ComponentModel.DataAnnotations;
using Pschool.Core.DTOs;
using Pschool.Core.Interface;
using Pschool.Infrastructure.IRepositories;
using Pschool.Infrastructure.Models;
using AutoMapper;

namespace Pschool.Core.Services
{
    public class ParentService : IParentService
    {
        private readonly IRepository<Parent> _repositoryParent;
        private readonly IMapper _mapper;

        public ParentService(IRepository<Parent> repositoryParent, IMapper mapper)
        {
            _repositoryParent = repositoryParent;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParentDto>?> GetParentsAsync()
        {
            var parents = await _repositoryParent.GetAllAsync();
            return _mapper.Map<IEnumerable<ParentDto>>(parents);
        }

        public async Task<ParentDto?> GetParentsByIdAsync(int id)
        {
            var parent = await _repositoryParent.GetByIdAsync(id);
            return _mapper.Map<ParentDto>(parent);
        }

        public async Task<ParentDto?> AddParentAsync(ParentDto parentDto)
        {
            var existParent = await _repositoryParent.GetByEmailAsync(parentDto.Email);
            if (existParent != null)
            {
                throw new ValidationException("A parent with this email already exists.");
            }

            var parent = _mapper.Map<Parent>(parentDto);
            await _repositoryParent.AddAsync(parent);
            return _mapper.Map<ParentDto>(parent);
        }

        public async Task<ParentDto?> UpdateParentAsync(int id, ParentDto parentDto)
        {
            var parent = await _repositoryParent.GetByIdAsync(id);
            if (parent == null) throw new ValidationException("Parent not found.");

            _mapper.Map(parentDto, parent);
            await _repositoryParent.UpdateAsync(parent);
            return _mapper.Map<ParentDto>(parent);
        }

        public async Task<bool> DeleteParentAsync(int id)
        {
            var parent = await _repositoryParent.GetByIdAsync(id);
            if (parent == null) throw new ValidationException("Parent not found.");

            await _repositoryParent.DeleteAsync(parent);
            return true;
        }
    }
}
