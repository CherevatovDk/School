using Microsoft.AspNetCore.Mvc;
using Pschool.Core.DTOs;
using Pschool.Core.Interface;

namespace Pschool.API.Controller;


[ApiController]
[Route("[controller]")]
public class ParentController(IParentService parentService) : ControllerBase
{
    private readonly IParentService _parentService = parentService;

    [HttpGet("all-Parents")]
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

    [HttpPost("add-parents")]
    public async Task<IActionResult> AddParents([FromBody] ParentDto parentDto)
    {
        var parent = await _parentService.AddParentAsync(parentDto);
        return CreatedAtAction(nameof(GetParentById), new { id = parent.Id },parent);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateParent([FromBody]ParentDto parentDto, int id)
    {
        var updateParent = await _parentService.UpdateParentAsync(id, parentDto);
        if (updateParent == null) return NotFound();
        return Ok((updateParent));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult>Delete(int id)
    {
        var deleted =await _parentService.DeleteParentAsync(id);
        if (!deleted) return NotFound();
        return Ok(deleted);
    }
}