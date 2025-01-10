using System.ComponentModel.DataAnnotations;

namespace SchoolDBProject.Models
{
    public class UpdateSubjectDTO
    {
        [Required(ErrorMessage = "Subject name is required.")]
        [StringLength(100, ErrorMessage = "Subject name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Subject code is required.")]
        public string? Code { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }
    }
}
