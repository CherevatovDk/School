using System.Net.Http.Json;
using Pschool.Core.DTOs;
using Pschool.BlazorWasm.IServices;

namespace Pschool.BlazorWasm.Services
{
    public class StudentService : IStudentService
    {
        private readonly IHttpClientService _httpClientService;

        public StudentService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            return await _httpClientService.SendRequestAsync<List<StudentDto>>("students");
        }

        public async Task<List<StudentDto>> GetStudentsByParentIdAsync(int parentId)
        {
            return await _httpClientService.SendRequestAsync<List<StudentDto>>($"students/parent/{parentId}");
        }

        public async Task<StudentDto?> GetStudentByIdAsync(int id)
        {
            return await _httpClientService.SendRequestAsync<StudentDto>($"students/{id}");
        }

        public async Task<StudentDto?> AddStudentAsync(StudentDto studentDto)
        {
            return await _httpClientService.SendRequestAsync<StudentDto>("students", HttpMethod.Post, studentDto);
        }

        public async Task<StudentDto?> UpdateStudentAsync(int id, StudentDto studentDto)
        {
            return await _httpClientService.SendRequestAsync<StudentDto>($"students/{id}", HttpMethod.Put, studentDto);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var response = await _httpClientService.SendRequestAsync<object>($"students/{id}", HttpMethod.Delete);
            return response != null;
        }
    }
}