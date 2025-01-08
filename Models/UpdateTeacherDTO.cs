using System.ComponentModel.DataAnnotations;

namespace SchoolDBProject.Models
{
    public class UpdateTeacherDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public int[]? SubjectIds { get; set; }

        [Range(0, 50, ErrorMessage = "Experience must be between 0 and 50 years.")]
        public int? ExperienceYears { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? Email { get; set; }

        public string? Position { get; set; }

        public int[]? ClassIds { get; set; }
    }
}
