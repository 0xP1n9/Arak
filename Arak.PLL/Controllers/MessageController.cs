using Arak.BLL.Service.Abstraction;
using Arak.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arak.PLL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _MessageService;

        public MessageController(IMessageService MessageService)
        {
            _MessageService = MessageService;
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _MessageService.GetAllMessages());
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Teacher,Parent")]
        public async Task<IActionResult> GetById(int id)
        {
            var msg = await _MessageService.GetMessageById(id);
            if (msg == null)
                return NotFound($"Invalid Id {id}");

            return Ok(msg);
        }

       
        [HttpGet("user/{userId}")]
        [Authorize(Roles = "Admin,Teacher,Parent")]
        public async Task<IActionResult> GetUserMessages(int userId)
        {
            var msgs = await _MessageService.GetMessagesByUser(userId);
            if (!msgs.Any())
                return NotFound($"No messages for user {userId}");

            return Ok(msgs);
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin,Teacher,Parent")]
        public async Task<IActionResult> Send(Message message)
        {
            return Ok(await _MessageService.SendMessage(message));
        }

        [HttpPut("read/{id}")]
        [Authorize(Roles = "Teacher,Parent")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            return Ok(await _MessageService.MarkAsRead(id));
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _MessageService.DeleteMessage(id);
            if (!result)
                return NotFound($"Invalid Id {id}");

            return Ok("Deleted successfully");
        }
    }
}
