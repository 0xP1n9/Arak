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
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<IEnumerable<Assignment>> GetAllAssignments()
        {
            return await _assignmentRepository.GetAllAsync();
        }

        public async Task<ICollection<Assignment>> GetAssignmentsByClassId(int classId)
        {
            return await _assignmentRepository.GetAssignmentByClassId(classId);
        }

        public async Task<Assignment> GetAssignmentsById(int id)
        {
            return await _assignmentRepository.GetByIdAsync(id);
        }

        public async Task<Assignment> CreateAssignment(Assignment assignment)
        {
            return await _assignmentRepository.CreateAsync(assignment);
        }

        public async Task<bool> DeleteAsync(int Id)
        {

            var result = await _assignmentRepository.DeleteAsync(Id);
            return result;
        }
    }
}
