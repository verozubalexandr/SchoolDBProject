using Microsoft.AspNetCore.Mvc;
using SchoolDBProject.Models;
using SchoolDBProject.Services;
using System.Linq;

namespace SchoolDBProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly SubjectService _subjectService;

        public SubjectsController(SubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        //get all subjects
        [HttpGet("get-all-subjects")]
        public IActionResult GetAllSubjects()
        {
            var subjects = _subjectService.GetAllSubjects();
            if (subjects == null || !subjects.Any())
            {
                return NotFound("No subjects found.");
            }
            return Ok(subjects);
        }

        //get subject by ID
        [HttpGet("get-subject/{id}")]
        public IActionResult GetSubjectById(int id)
        {
            var subject = _subjectService.GetSubjectById(id);
            if (subject == null)
            {
                return NotFound($"Subject with ID {id} not found.");
            }
            return Ok(subject);
        }

        //add new subject
        [HttpPost("add-subject")]
        public IActionResult AddSubject([FromBody] Subject subject)
        {
            if (subject == null)
            {
                return BadRequest("Subject cannot be null.");
            }

            _subjectService.AddSubject(subject);
            return CreatedAtAction(nameof(GetSubjectById), new { id = subject.Name }, subject);
        }

        //update an existing subject
        [HttpPut("update-subject/{id}")]
        public IActionResult UpdateSubject(int id, [FromBody] SubjectDTO subjectDTO)
        {
            try
            {
                _subjectService.UpdateSubject(id, subjectDTO);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //delete subject by ID
        [HttpDelete("delete-subject/{id}")]
        public IActionResult DeleteSubject(int id)
        {
            var subject = _subjectService.GetSubjectById(id);
            if (subject == null)
            {
                return NotFound($"Subject with ID {id} not found.");
            }

            _subjectService.DeleteSubject(id);
            return NoContent();
        }
    }
}
