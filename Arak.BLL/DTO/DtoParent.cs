using Arak.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.DTO
{
    public class DtoParent
    {
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
