using Arak.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.DAL.Repository.Abstraction
{
    public interface IAttendanceRepository : IGenericRepository<Attendance>
    {
        Task<ICollection<Attendance>> GetAttendanceByClassId(int classId);
    }
}
