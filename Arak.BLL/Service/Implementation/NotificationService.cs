using Arak.DAL.Entities;
using Arak.DAL.Repository.Abstraction;
using Arak.BLL.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.Service.Implementation
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _NotificationService;

        public NotificationService(INotificationRepository NotificationService)
        {
            _NotificationService = NotificationService;
        }

        public async Task<Notification> CreateNotification(Notification notification)
        {
            return await _NotificationService.CreateAsync(notification);
        }

        public async Task<IEnumerable<Notification>> GetAllNotifications()
        {
            return await _NotificationService.GetAllAsync();
        }

        public async Task<Notification> GetNotificationById(int id)
        {
            return await _NotificationService.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Notification>> GetUserNotifications(int userId)
        {
            var all = await _NotificationService.GetAllAsync();
            return all.Where(x => x.UserId == userId);
        }

        public async Task<Notification> MarkAsRead(int id)
        {
            var notif = await _NotificationService.GetByIdAsync(id);
            notif.IsRead = true;
            return await _NotificationService.UpdateAsync(notif);
        }

        public async Task<bool> DeleteNotification(int id)
        {
            return await _NotificationService.DeleteAsync(id);
        }
    }
}
