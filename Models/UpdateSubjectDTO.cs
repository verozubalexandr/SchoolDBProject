using System.ComponentModel.DataAnnotations;

namespace SchoolDBProject.Models
{
    public class SubjectDTO
    {
        [Required(ErrorMessage = "Subject name is required.")]
        [StringLength(100, ErrorMessage = "Subject name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Subject code is required.")]
        [StringLength(10, ErrorMessage = "Subject code must be exactly 10 characters.")]
        public string? Code { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        public int[]? ClassIds { get; set; }
    }
}
