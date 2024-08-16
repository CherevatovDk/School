using Pschool.Core.DTOs;

namespace Pschool.Core.Interface;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetStudentsAsync();
    Task<StudentDto?> GetStudentByIdAsync(int id);
    Task<StudentDto?> AddStudentAsync(StudentDto studentDto);
    Task<StudentDto?> UpdateStudentAsync(int id, StudentDto studentDto);
    Task<bool> DeleteStudentAsync(int id);
    Task<IEnumerable<StudentDto>> GetStudentsByParentIdAsync(int parentId);
    
}