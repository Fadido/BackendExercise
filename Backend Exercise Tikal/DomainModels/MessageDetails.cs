using Backend_Exercise_Tikal.Controllers;

namespace Backend_Exercise_Tikal
{
    public class MessageDetails : IMessageDetails
    {
        public Recipient Recipient { get; set; }
        public Sender Sender { get; set; }
        public Message Message { get; set; }
    }
}