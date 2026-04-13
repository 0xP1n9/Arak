using Arak.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.Service.Abstraction
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendance>> GetAllAttendances();
        Task<Attendance> GetAttendanceById(int id);
        Task<ICollection<Attendance>> GetAttendanceByClassId(int classId);
        Task<Attendance> CreateAttendance(Attendance attendance);
        Task<Attendance> UpdateAttendance(Attendance attendance);
        Task<bool> DeleteAttendance(int id);
    }
}
