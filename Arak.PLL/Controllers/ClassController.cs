using Arak.BLL.Service.Abstraction;
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
    }
}
