using Arak.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.Service.Abstraction
{
    public interface IAssignmentService
    {
        Task<IEnumerable<Assignment>> GetAllAssignments();
        Task<Assignment> GetAssignmentsById(int id);
        Task<ICollection<Assignment>> GetAssignmentsByClassId(int classId);
        Task<Assignment> CreateAssignment(Assignment assignment);
        Task<bool> DeleteAsync(int Id);
    }
}
