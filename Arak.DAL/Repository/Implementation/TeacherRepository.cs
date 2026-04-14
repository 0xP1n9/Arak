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
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context) : base(context) { }

        public async Task<ICollection<Teacher>> GetByNameAsync(string name)
        {
            var teacher = await _context.Teachers.Where(x => x.TeacherName == name).ToListAsync();
            return teacher;
        }

        public async Task<ICollection<Teacher>> GetByEmailAsync(string email)
        {
            var teachers = await _context.Teachers.Where(x => x.Email == email).ToListAsync();
            return teachers;
        }

        public async Task<ICollection<Teacher>> GetByDepartemntAsync(string department)
        {
            var teachers = await _context.Teachers.Where(x => x.Department == department).ToListAsync();
            return teachers;
        }

        public async Task<ICollection<Teacher>> GetTeachersBySubjectId(int subjectId)
        {
            var teachers = await _context.Teachers.Where(x => x.SubjectId == subjectId).ToListAsync();
            return teachers;
        }
    }
}
