using Arak.BLL.Service.Abstraction;
using Arak.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arak.PLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClassById(int id)
        {
            var classes = await _classService.GetClassById(id);
            if (classes == null)
            {
                return NotFound($"The Id {id} is invalid!");
            }

            return Ok(classes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass(Class classes)
        {
            var CreatedClass= await _classService.CreateClass(classes);
            return Ok(CreatedClass);
        }
    }
}
