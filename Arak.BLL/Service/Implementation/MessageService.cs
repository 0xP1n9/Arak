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
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _MessageRepository;

        public MessageService(IMessageRepository MessageRepository)
        {
            _MessageRepository = MessageRepository;
        }

        public async Task<Message> SendMessage(Message message)
        {
            return await _MessageRepository.CreateAsync(message);
        }

        public async Task<IEnumerable<Message>> GetAllMessages()
        {
            return await _MessageRepository.GetAllAsync();
        }

        public async Task<Message> GetMessageById(int id)
        {
            return await _MessageRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Message>> GetMessagesByUser(int userId)
        {
            var all = await _MessageRepository.GetAllAsync();
            return all.Where(x => x.SenderId == userId || x.ReceiverId == userId);
        }

        public async Task<Message> MarkAsRead(int id)
        {
            var msg = await _MessageRepository.GetByIdAsync(id);
            msg.IsRead = true;
            return await _MessageRepository.UpdateAsync(msg);
        }

        public async Task<bool> DeleteMessage(int id)
        {
            return await _MessageRepository.DeleteAsync(id);
        }
    }
}
