using Arak.BLL.Service.Abstraction;
using Arak.DAL.Entities;
using Arak.DAL.Repository.Abstraction;
using Arak.DAL.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.Service.Implementation
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendances()
        {
            return await _attendanceRepository.GetAllAsync();
        }

        public async Task<Attendance> GetAttendanceById(int id)
        {
            return await _attendanceRepository.GetByIdAsync(id);
        }

        public async Task<ICollection<Attendance>> GetAttendanceByClassId(int classId)
        {
            return await _attendanceRepository.GetAttendanceByClassId(classId);
        }

        public async Task<Attendance> CreateAttendance(Attendance attendance)
        {
            return await _attendanceRepository.CreateAsync(attendance);
        }

        public async Task<Attendance> UpdateAttendance(Attendance attendance)
        {
            return await _attendanceRepository.UpdateAsync(attendance);
        }

        public async Task<bool> DeleteAttendance(int id)
        {
            return await _attendanceRepository.DeleteAsync(id);
        }
    }
}
