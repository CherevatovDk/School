using Microsoft.AspNetCore.Mvc;
using Pschool.Core.DTOs;
using Pschool.Core.Interface;

namespace Pschool.API.Controller;


[ApiController]
[Route("[controller]")]
public class ParentController(IParentService parentService) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IActionResult> GetAllParents()
    {
        var parents = await parentService.GetParentsAsync();
        return Ok(parents);//TODO 204
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetParentById(int id)
    {
        var parent = await parentService.GetParentsByIdAsync(id);
        if (parent == null) return NotFound();
        return Ok(parent);//TODO 204
    }

    [HttpPost("add")]
    public async Task<ParentDto?> AddParents([FromBody] ParentDto parentDto)
    {
        var parent = await parentService.AddParentAsync(parentDto);
        return parent;//TODO 201
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateParent([FromBody]ParentDto parentDto, int id)
    {
        var updateParent = await parentService.UpdateParentAsync(id, parentDto);
        if (updateParent == null) return NotFound(); //TODO uses validation from service parents and throw ne custom exception which will be caught error handling filter  
        return Ok((updateParent));//TODO 204
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult>Delete(int id)
    {
        var deleted =await parentService.DeleteParentAsync(id);
        if (!deleted) return NotFound();//TODO uses validation from service parents and throw ne custom exception which will be caught error handling filter  
        return Ok(deleted); //TODO return 204
    }
}