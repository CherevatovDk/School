using System.ComponentModel.DataAnnotations;

namespace Pschool.Core.DTOs
{
    public class ParentDto
    {
        public int Id { get; set; }

        // [Required(ErrorMessage = "First name is required")]
        // [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string? FirstName { get; set; }

        // [Required(ErrorMessage = "Last name is required")]
        // [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string? LastName { get; set; }

        // [Required(ErrorMessage = "Username is required")]
        // [StringLength(20, ErrorMessage = "Username cannot exceed 20 characters")]
        public string? Username { get; set; }

        // [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string? Email { get; set; }

        // [StringLength(100, ErrorMessage = "Home address cannot exceed 100 characters")]
        public string? HomeAddress { get; set; }

        // [Phone(ErrorMessage = "Invalid phone number format")]
        public string? Phone1 { get; set; }

        // [Phone(ErrorMessage = "Invalid phone number format")]
        public string? WorkPhone { get; set; }

        // [Phone(ErrorMessage = "Invalid phone number format")]
        public string? HomePhone { get; set; }

        // [Range(0, int.MaxValue, ErrorMessage = "Number of siblings must be non-negative")]
        public int Siblings { get; set; }
    }
}