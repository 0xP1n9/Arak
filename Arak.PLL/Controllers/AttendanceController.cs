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
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> GetAllAttendances()
        {
            var attendance = await _attendanceService.GetAllAttendances();
            return Ok(attendance);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Parent,Admin")]
        public async Task<IActionResult> GetAttendanceById(int id)
        {
            var attendance = await _attendanceService.GetAttendanceById(id);
            if (attendance == null)
            {
                return NotFound($"The Id {id} is invalid!");
            }

            return Ok(attendance);
        }

        [HttpGet("SearchAttendancesByClassId/{classId}")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> GetAttendanceByClassId(int classId)
        {
            var attendances = await _attendanceService.GetAttendanceByClassId(classId);
            if (attendances.Any() == false)
            {
                return NotFound($"The ClassId {classId} is invalid!");
            }
            return Ok(attendances);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> CreateAttendance(Attendance attendance)
        {
            var NewAttendance = await _attendanceService.CreateAttendance(attendance);
            return Ok(NewAttendance);
        }

        [HttpPut]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> UpdateAttendance(int id, Attendance attendance)
        {
            if (id != attendance.Id)
            {
                return NotFound($"The Id {id} is invalid!");
            }

            var UpdatedAttendance = await _attendanceService.UpdateAttendance(attendance);
            return Ok(UpdatedAttendance);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            var attendance = await _attendanceService.DeleteAttendance(id);
            if (!attendance)
            {
                return NotFound($"The Id {id} is invalid!");
            }

            return Ok("Attendance had been deleted Successfully!");
        }
    }
}
