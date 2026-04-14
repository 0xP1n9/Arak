using Arak.BLL.Service.Abstraction;
using Arak.BLL.Service.Implementation;
using Arak.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arak.PLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        [Authorize(Roles = "Parent,Teacher,Admin")]
        public async Task<IActionResult> GetAllAssignments()
        {
            var assignments = await _assignmentService.GetAllAssignments();
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Parent,Teacher,Admin")]
        public async Task<IActionResult> GetAssignmentById(int id)
        {
            var assignment = await _assignmentService.GetAssignmentsById(id);
            if (assignment == null)
            {
                return NotFound($"The Id {id} is invalid!");
            }

            return Ok(assignment);
        }

        [HttpGet("GetAssignmentByClassId/{classId}")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> GetAssignmentByClassId(int classId)
        {
            var Assignment = await _assignmentService.GetAssignmentsByClassId(classId);
            if (Assignment.Any() == false)
            {
                return NotFound($"The ClassId {classId} is invalid!");
            }

            return Ok(Assignment);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> CreateAssignment(Assignment assignment)
        {
            var CreatedAssignment = await _assignmentService.CreateAssignment(assignment);
            return Ok(CreatedAssignment);
        }

        [HttpDelete]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var result = await _assignmentService.DeleteAsync(Id);
            if (!result)
            {
                return NotFound($"The Id {Id} is invalid!");
            }

            return Ok("Assignment had been deleted successfully!");
        }

    }
}
