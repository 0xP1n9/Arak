using Arak.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.Service.Abstraction
{
    public interface ISemesterService
    {
        Task<IEnumerable<Semester>> GetAllSemesters();
        Task<Semester> GetSemestertById(int id);
        Task<Semester> CreateSemester(Semester semester);
        Task<Semester> UpdateSemester(Semester semester);
        Task<bool> DeleteSemester(int id);
    }
}
