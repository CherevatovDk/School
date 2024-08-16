using System.Linq.Expressions;
using AutoMapper;
using Pschool.Core.DTOs;
using Pschool.Core.Interface;
using Pschool.Infrastructure.IRepositories;
using Pschool.Infrastructure.Models;

namespace Pschool.Core.Services
{
    public class StudentService(IRepository<Student> studentRepository, IMapper mapper) : IStudentService
    {
        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            var students = await studentRepository.GetAllAsync();
            return mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto?> GetStudentByIdAsync(int id)
        {
            var student = await studentRepository.GetByIdAsync(id);
            return mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto?> AddStudentAsync(StudentDto studentDto)
        {
            var student = mapper.Map<Student>(studentDto);
            await studentRepository.AddAsync(student);
            return mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto?> UpdateStudentAsync(int id, StudentDto studentDto)
        {
            var student = await studentRepository.GetByIdAsync(id);
            if (student == null) return null;

            mapper.Map(studentDto, student);
            await studentRepository.UpdateAsync(student);
            return mapper.Map<StudentDto>(student);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await studentRepository.GetByIdAsync(id);
            if (student == null) return false;

            await studentRepository.DeleteAsync(student);
            return true;
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsByParentIdAsync(int parentId)
        {
            Expression<Func<Student, bool>> filter = s => s.ParentId == parentId;
            var students = await studentRepository.GetByExpressionAsync(filter);
            return mapper.Map<IEnumerable<StudentDto>>(students);
        }
    }
}
