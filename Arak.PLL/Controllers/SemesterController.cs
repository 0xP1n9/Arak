using Arak.BLL.Service.Abstraction;
using Arak.BLL.Service.Implementation;
using Arak.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arak.PLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterService _semesterService;
        public SemesterController(ISemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSemesters()
        {
            var subject = await _semesterService.GetAllSemesters();
            return Ok(subject);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSemesterById(int id)
        {
            var semester = await _semesterService.GetSemestertById(id);
            if (semester == null)
            {
                return NotFound($"The Id {id} is invalid!");
            }

            return Ok(semester);
        }

        [HttpPost]
        public async Task<IActionResult> AddSemester(Semester semester)
        {
            var NewSemester = await _semesterService.CreateSemester(semester);
            return Ok(NewSemester);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSemester(int id, Semester semester)
        {
            if (id != semester.Id)
            {
                return NotFound($"The Id {id} is invalid!");
            }

            var UpdatedSemester = await _semesterService.UpdateSemester(semester);
            return Ok(UpdatedSemester);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSemester(int id)
        {
            var subject = await _semesterService.DeleteSemester(id);
            if (!subject)
            {
                return NotFound($"The Id {id} is invalid!");
            }

            return Ok("Semester had been deleted Successfully!");
        }
    }
}
