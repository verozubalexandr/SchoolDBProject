using System.ComponentModel.DataAnnotations;

namespace SchoolDBProject.Models
{
    public class UpdateEmployeeDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string? Email { get; set; }
    }
}
