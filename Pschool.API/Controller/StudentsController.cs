using Microsoft.AspNetCore.Mvc;
using Pschool.Core.DTOs;
using Pschool.Core.Interface;

namespace Pschool.API.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController(IStudentService studentService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await studentService.GetStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] StudentDto studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdStudent = await studentService.AddStudentAsync(studentDto);
            return CreatedAtAction(nameof(GetStudent), new { id = createdStudent?.Id }, createdStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, [FromBody] StudentDto studentDto)
        {
            if (id != studentDto.Id)
            {
                return BadRequest();
            }

            var updatedStudent = await studentService.UpdateStudentAsync(id, studentDto);
            if (updatedStudent == null)
            {
                return NotFound();
            }

            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var success = await studentService.DeleteStudentAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("parent/{parentId}")]
        public async Task<IActionResult> GetStudentsByParentId(int parentId)
        {
            var students = await studentService.GetStudentsByParentIdAsync(parentId);
            return Ok(students);
        }
    }
}