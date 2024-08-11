namespace Pschool.Infrastructure.Models;

public class Parent
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? HomeAddress { get; set; }
    public string? Phone1 { get; set; }
    public string? WorkPhone { get; set; }
    public string? HomePhone { get; set; }
    public int Siblings { get; set; }
    public ICollection<Student>? Students { get; set; }
}