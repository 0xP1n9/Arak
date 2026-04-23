using Arak.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak.BLL.Service.Abstraction
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetAllMessages();
        Task<Message> GetMessageById(int id);
        Task<IEnumerable<Message>> GetMessagesByUser(int userId);

        Task<Message> SendMessage(Message message);
        Task<Message> MarkAsRead(int id);
        Task<bool> DeleteMessage(int id);
    }
}
