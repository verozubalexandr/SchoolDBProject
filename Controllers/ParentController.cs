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
