using Microsoft.AspNetCore.Mvc;
using Pschool.Core.DTOs;
using Pschool.Core.Interface;

namespace Pschool.API.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _parentService;

        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllParents()
        {
            var parents = await _parentService.GetParentsAsync();
            return Ok(parents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParentById(int id)
        {
            var parent = await _parentService.GetParentsByIdAsync(id);
            if (parent == null) return NotFound();
            return Ok(parent);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddParent([FromBody] ParentDto parentDto)
        {
            var parent = await _parentService.AddParentAsync(parentDto);
            return CreatedAtAction(nameof(GetParentById), new { id = parent.Id }, parent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParent(int id, [FromBody] ParentDto parentDto)
        {
            var updatedParent = await _parentService.UpdateParentAsync(id, parentDto);
            if (updatedParent == null) return NotFound();
            return Ok(updatedParent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParent(int id)
        {
            var deleted = await _parentService.DeleteParentAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}