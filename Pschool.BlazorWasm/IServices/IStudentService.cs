using Pschool.Core.DTOs;

namespace Pschool.BlazorWasm.IServices
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllStudentsAsync();
        Task<List<StudentDto>> GetStudentsByParentIdAsync(int parentId);
        Task<StudentDto?> GetStudentByIdAsync(int id);
        Task<StudentDto?> AddStudentAsync(StudentDto studentDto);
        Task<StudentDto?> UpdateStudentAsync(int id, StudentDto studentDto);
        Task<bool> DeleteStudentAsync(int id);
    }
}