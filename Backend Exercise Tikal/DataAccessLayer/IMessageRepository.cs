using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Exercise_Tikal.DataAccessLayer
{
    public interface IMessageRepository
    {
        void SaveMessage(IMessageDetails messageDetails);

        List<IMessageDetails> GetMessages(int recipientId);

    }
}
