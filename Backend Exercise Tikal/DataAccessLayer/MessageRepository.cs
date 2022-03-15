using Backend_Exercise_Tikal.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Exercise_Tikal.DataAccessLayer
{
    public class MessageRepository: IMessageRepository
    {
        static Dictionary<int, List<IMessageDetails>> inMemoryKeyValueCache = new Dictionary<int, List<IMessageDetails>>();

        public void SaveMessage(IMessageDetails messageDetails)
        {
            var rid = messageDetails.Recipient.RecipientId;
            if (!inMemoryKeyValueCache.ContainsKey(rid))
            {
                inMemoryKeyValueCache.Add(rid, new List<IMessageDetails>() { messageDetails });
                return;
            }
            inMemoryKeyValueCache[rid].Add(messageDetails);
        }

        public List<IMessageDetails> GetMessages(int recipientId)
        {
            if (!inMemoryKeyValueCache.ContainsKey(recipientId))
                throw new KeyNotFoundException("Recpient Id was not found");
            return inMemoryKeyValueCache[recipientId];
        }
    }
}
