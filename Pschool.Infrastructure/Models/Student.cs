namespace Pschool.Infrastructure.Models;

public class Student
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int ParentId { get; set; }
    public Parent? Parent { get; set; }
}