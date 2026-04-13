using Arak.BLL.Service.Abstraction;
using Arak.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.Service.Implementation
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentRepository;
        public ParentService(IParentRepository parentRepository)
        {
            _parentRepository = parentRepository;
        }


    }
}
