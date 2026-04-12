using Arak.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.Service.Abstraction
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetAllSubjects();
        Task<Subject> GetSubjectById(int id);
        Task<Subject> CreateSubject(Subject subject);
        Task<Subject> UpdateSubject(Subject subject);
        Task<bool> DeleteSubject(int id);
    }
}
