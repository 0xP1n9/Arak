using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.Service.Abstraction
{
    public interface IUserService
    {
        Task<bool> DeleteUserAsync(string id);
    }
}
