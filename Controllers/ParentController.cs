using Microsoft.AspNetCore.Mvc;
using SchoolDBProject.Models;
using SchoolDBProject.Services;

namespace SchoolDBProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentsController : ControllerBase
    {
        private readonly ParentService _parentService;

        public ParentsController(ParentService parentService)
        {
            _parentService = parentService;
        }

        //get all parents
        [HttpGet("get-all-parents")]
        public IActionResult GetAllParents()
        {
            return Ok(_parentService.GetAllParents());
        }

        //get parent by id
        [HttpGet("get-parent/{id}")]
        public IActionResult GetParentById(int id)
        {
            var parent = _parentService.GetParentById(id);
            if (parent == null)
            {
                return NotFound();
            }
            return Ok(parent);
        }

        //get parents by child id
        [HttpGet("get-parents-by-child/{childId}")]
        public IActionResult GetParentsByChildId(int childId)
        {
            var parents = _parentService.GetParentsByChildId(childId);
            if (parents == null || !parents.Any())
            {
                return NotFound($"No parents found for child with ID {childId}.");
            }
            return Ok(parents);
        }

        //get parents by name or last name
        [HttpGet("get-parents-by-name")]
        public IActionResult GetParentsByName([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name query parameter is required.");
            }

            var parents = _parentService.GetParentsByName(name);
            if (parents == null || !parents.Any())
            {
                return NotFound($"No parents found with name or surname containing '{name}'.");
            }

            return Ok(parents);
        }

        //add new parent
        [HttpPost("add-parent")]
        public IActionResult AddParent([FromBody] Parent parent)
        {
            if (parent == null)
            {
                return BadRequest("Parent cannot be null.");
            }

            _parentService.AddParent(parent);
            return CreatedAtAction(nameof(GetParentById), new { id = parent.Id }, parent);
        }

        //update existing parent
        [HttpPut("update-parent/{id}")]
        public IActionResult UpdateParent(int id, [FromBody] UpdateParentDTO parentDto)
        {
            try
            {
                _parentService.UpdateParent(id, parentDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //delete parent by id
        [HttpDelete("delete-parent/{id}")]
        public IActionResult DeleteParent(int id)
        {
            _parentService.DeleteParent(id);
            return NoContent();
        }
    }
}
