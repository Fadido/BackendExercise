using Backend_Exercise_Tikal.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Exercise_Tikal
{
    public class MessageService : IMessageService
    {
        private IMessageRepository _messageRepository = new MessageRepository();

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public List<IMessageDetails> GetMessagesByRecipientId(int recipientId) =>
            _messageRepository.GetMessages(recipientId);

        public void SaveMessage(IMessageDetails messageDetails) => 
            _messageRepository.SaveMessage(messageDetails);
    }
}
