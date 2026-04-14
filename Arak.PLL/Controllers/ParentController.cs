using Arak.BLL.Service.Abstraction;
using Arak.BLL.Service.Implementation;
using Arak.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arak.PLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _parentService;
        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateStudent(Parent parent)
        {
            var prnt = await _parentService.CreateAsync(parent);
            return Ok(prnt);
        }

    }
}
