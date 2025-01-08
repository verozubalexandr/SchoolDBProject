using Microsoft.AspNetCore.Mvc;
using SchoolDBProject.Models;
using SchoolDBProject.Services;

namespace SchoolDBProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassesController : ControllerBase
    {
        private readonly ClassService _classService;

        public ClassesController(ClassService classService)
        {
            _classService = classService;
        }

        //get all classes
        [HttpGet("get-all-classes")]
        public IActionResult GetAllClasses()
        {
            var classes = _classService.GetAllClasses();
            if (classes == null || !classes.Any())
            {
                return NotFound("No classes found.");
            }
            return Ok(classes);
        }

        //get class by ID
        [HttpGet("get-class/{id}")]
        public IActionResult GetClassById(int id)
        {
            var classObj = _classService.GetClassById(id);
            if (classObj == null)
            {
                return NotFound($"Class with ID {id} not found.");
            }
            return Ok(classObj);
        }

        //add a new class
        [HttpPost("add-class")]
        public IActionResult AddClass([FromBody] Class classObj)
        {
            if (classObj == null)
            {
                return BadRequest("Class cannot be null.");
            }

            _classService.AddClass(classObj);
            return CreatedAtAction(nameof(GetClassById), new { id = classObj.Id }, classObj);
        }

        //update class by ID
        [HttpPut("update-class/{id}")]
        public IActionResult UpdateClass(int id, [FromBody] UpdateClassDTO classDto)
        {
            try
            {
                _classService.UpdateClass(id, classDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //delete class by ID
        [HttpDelete("delete-class/{id}")]
        public IActionResult DeleteClass(int id)
        {
            var classObj = _classService.GetClassById(id);
            if (classObj == null)
            {
                return NotFound($"Class with ID {id} not found.");
            }

            _classService.DeleteClass(id);
            return NoContent();
        }
    }
}
