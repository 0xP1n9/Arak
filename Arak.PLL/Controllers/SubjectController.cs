using Arak.BLL.Service.Abstraction;
using Arak.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arak.PLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subject = await _subjectService.GetAllSubjects();
            return Ok(subject);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            var subject = await _subjectService.GetSubjectById(id);
            if (subject == null)
            {
                return NotFound($"The Id {id} is invalid!");
            }

            return Ok(subject);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddSubject(Subject subject)
        {
            var NewSubject = await _subjectService.CreateSubject(subject);
            return Ok(NewSubject);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateSubject(int id,Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound($"The Id {id} is invalid!");
            }

            var UpdatedSubject=await _subjectService.UpdateSubject(subject);
            return Ok(UpdatedSubject);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _subjectService.DeleteSubject(id);
            if (!subject)
            {
                return NotFound($"The Id {id} is invalid!");
            }

            return Ok("Subject had been deleted Successfully!");
        }
    }
}
