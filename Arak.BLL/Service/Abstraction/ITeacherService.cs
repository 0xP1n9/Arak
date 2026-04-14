using Arak.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.Service.Abstraction
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        Task<Teacher> GetTeachersByIdAsync(int id);
        Task<ICollection<Teacher>> GetByNameAsync(string name);
        Task<ICollection<Teacher>> GetByEmailAsync(string email);
        Task<ICollection<Teacher>> GetByDepartemntAsync(string department);
        Task<ICollection<Teacher>> GetTeachersBySubjectId(int subjectId);
        Task<Teacher> CreateAsync(Teacher teacher);
        Task<Teacher> UpdateAsync(Teacher teacher);
        Task<bool> DeleteAsync(int Id);
    }
}
