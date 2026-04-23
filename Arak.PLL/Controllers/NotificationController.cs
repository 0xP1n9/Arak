using Arak.BLL.Service.Abstraction;
using Arak.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arak.PLL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllNotifications());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Teacher,Parent")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetNotificationById(id));
        }

        [HttpGet("user/{userId}")]
        [Authorize(Roles = "Admin,Teacher,Parent")]
        public async Task<IActionResult> GetUserNotifications(int userId)
        {
            return Ok(await _service.GetUserNotifications(userId));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Create(Notification notification)
        {
            return Ok(await _service.CreateNotification(notification));
        }

        [HttpPut("read/{id}")]
        [Authorize(Roles = "Parent,Teacher")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            return Ok(await _service.MarkAsRead(id));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteNotification(id));
        }
    }
}