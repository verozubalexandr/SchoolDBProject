using System.ComponentModel.DataAnnotations;

namespace SchoolDBProject.Models
{
    public class Class
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int TeacherId { get; set; } 

        public int[] StudentIds { get; set; }

        public int[] SubjectIds { get; set; }

        public void RemoveSubject(int subjectId)
        {
            if (SubjectIds.Contains(subjectId))
            {
                SubjectIds = SubjectIds.Where(id => id != subjectId).ToArray();
            }
        }
    }
}
