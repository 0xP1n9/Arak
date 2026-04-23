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
        private readonly INotificationRepository _NotificationRepository;

        public NotificationService(INotificationRepository NotificationRepository)
        {
            _NotificationRepository = NotificationRepository;
        }

        public async Task<Notification> CreateNotification(Notification notification)
        {
            return await _NotificationRepository.CreateAsync(notification);
        }

        public async Task<IEnumerable<Notification>> GetAllNotifications()
        {
            return await _NotificationRepository.GetAllAsync();
        }

        public async Task<Notification> GetNotificationById(int id)
        {
            return await _NotificationRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Notification>> GetUserNotifications(int userId)
        {
            var all = await _NotificationRepository.GetAllAsync();
            return all.Where(x => x.UserId == userId);
        }

        public async Task<Notification> MarkAsRead(int id)
        {
            var notif = await _NotificationRepository.GetByIdAsync(id);
            notif.IsRead = true;
            return await _NotificationRepository.UpdateAsync(notif);
        }

        public async Task<bool> DeleteNotification(int id)
        {
            return await _NotificationRepository.DeleteAsync(id);
        }
    }
}
