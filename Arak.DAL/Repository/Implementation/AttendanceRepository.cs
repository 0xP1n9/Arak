using Arak.DAL.Database;
using Arak.DAL.Entities;
using Arak.DAL.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.DAL.Repository.Implementation
{
    public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(AppDbContext context) : base(context) { }
        public async Task<ICollection<Attendance>> GetAttendanceByClassId(int classId)
        {
            var attendances = await _context.Attendances.Where(x => x.ClassId == classId).ToListAsync();
            return attendances;
        }
    }
}
