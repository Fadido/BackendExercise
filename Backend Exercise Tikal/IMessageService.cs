using System.Collections.Generic;

namespace Backend_Exercise_Tikal
{
    public interface IMessageService
    {
        void SaveMessage(IMessageDetails messageDetails);
        List<IMessageDetails> GetMessagesByRecipientId(int recipientId);
    }
}