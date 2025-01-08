using System.ComponentModel.DataAnnotations;

namespace SchoolDBProject.Models
{
    public class UpdateStudentDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Range(6, 18, ErrorMessage = "Age must be between 6 and 18.")]
        public int? Age { get; set; }

        public int? ClassId { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? Email { get; set; }

        public int[]? ParentIds { get; set; }
    }
}
