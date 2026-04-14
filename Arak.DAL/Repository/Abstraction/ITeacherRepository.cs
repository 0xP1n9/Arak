using Arak.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.DAL.Repository.Abstraction
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<ICollection<Teacher>> GetByNameAsync(string name);
        Task<ICollection<Teacher>> GetByEmailAsync(string email);
        Task<ICollection<Teacher>> GetByDepartemntAsync(string department);
        Task<ICollection<Teacher>> GetTeachersBySubjectId(int subjectId);
    }
}
