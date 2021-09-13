using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using When2Watch.BLL.DTO;

namespace When2Watch.BLL.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDTO>> GetMessagesAsync(int userId, int friendId);
        Task CreateMessageAsync(MessageDTO message);
        Task UpdateMessageAsync(MessageDTO message);
        Task DeleteMessageAsync(int id);
    }
}
