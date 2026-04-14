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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllTeachers()
        {
            var allTeachers = await _teacherService.GetAllTeachersAsync();
            return Ok(allTeachers);
        }

        [HttpGet("SearchTeachersById/{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTeacherByIdAsync(int Id)
        {
            var teacher = await _teacherService.GetTeachersByIdAsync(Id);
            if (teacher == null)
            {
                return NotFound($"The Id {Id} is invalid!");
            }

            return Ok(teacher);

        }

        [HttpGet("SearchTeachersByName/{name}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var teacher = await _teacherService.GetByNameAsync(name);
            if (teacher.Any() == false)
            {
                return NotFound($"The Name {name} is invalid!");
            }
            return Ok(teacher);
        }

        [HttpGet("SearchTeachersByEmail/{email}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByEmailAsync(string email)
        {
            var teacher = await _teacherService.GetByEmailAsync(email);
            if (teacher.Any() == false)
            {
                return BadRequest($"The Email {email} is invalid!");
            }
            return Ok(teacher);
        }

        [HttpGet("SearchTeachersBySubjectId/{subjectId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTeacherBySubjectId(int subjectId)
        {
            var teacher = await _teacherService.GetTeachersBySubjectId(subjectId);
            if (teacher.Any() == false)
            {
                return NotFound($"The Subject {subjectId} is invalid!");
            }
            return Ok(teacher);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTeacher(Teacher teacher)
        {
            var tchr = await _teacherService.CreateAsync(teacher);
            return Ok(teacher);
        }

        [HttpPut]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> UpdateAsync(int Id, Teacher teacher)
        {
            if (Id != teacher.Id)
            {
                return NotFound($"The Id {Id} is invalid!");
            }
            var tchr = await _teacherService.UpdateAsync(teacher);
            return Ok(teacher);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var result = await _teacherService.DeleteAsync(Id);
            if (!result)
            {
                return NotFound($"The Id {Id} is invalid!");
            }

            return Ok("Teacher had been deleted successfully!");
        }
    }
}
