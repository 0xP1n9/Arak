using Arak.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.Service.Abstraction
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllNotifications();
        Task<Notification> GetNotificationById(int id);
        Task<IEnumerable<Notification>> GetUserNotifications(int userId);

        Task<Notification> CreateNotification(Notification notification);
        Task<Notification> MarkAsRead(int id);
        Task<bool> DeleteNotification(int id);
    }
}
