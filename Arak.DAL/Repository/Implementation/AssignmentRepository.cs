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
    public class AssignmentRepository : GenericRepository<Assignment>,IAssignmentRepository
    {
        private readonly IAssignmentRepository _assignmentRepository;
        public AssignmentRepository(AppDbContext context) : base(context) { }

        public async Task<ICollection<Assignment>> GetAssignmentByClassId(int classId)
        {
            var assignment = await _context.Assignments.Where(x => x.ClassId == classId).ToListAsync();
            return assignment;
        }
    }
}
