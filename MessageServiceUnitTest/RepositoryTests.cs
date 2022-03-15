using Backend_Exercise_Tikal;
using Backend_Exercise_Tikal.Controllers;
using Backend_Exercise_Tikal.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace MessageServiceUnitTest
{
    public class RepositoryTests
    {
        [Fact]
        public void GetMessagesKeyNotFound()
        {
            var notExistingKey = 1;
            IMessageRepository messageRepository = new MessageRepository();
            Assert.Throws<KeyNotFoundException>(() => messageRepository.GetMessages(notExistingKey));
        }

        [Fact]
        public void GetMessages()
        {
            var recipientId = 2;
            IMessageRepository messageRepository = new MessageRepository();

            messageRepository.SaveMessage(new MessageDetails
            {
                Sender = new Sender { SenderId = 1 },
                Recipient = new Recipient { RecipientId = recipientId },
                Message = new Message { MessageId = 1, Date = DateTime.Now, Content = "hello" }
            });
            messageRepository.SaveMessage(new MessageDetails
            {
                Sender = new Sender { SenderId = 3 },
                Recipient = new Recipient { RecipientId = recipientId },
                Message = new Message { MessageId = 1, Date = DateTime.Now, Content = "world" }
            });

            var recipientMessages = messageRepository.GetMessages(recipientId);
            Assert.Equal(2, recipientMessages.Count);
        }
    }
}
