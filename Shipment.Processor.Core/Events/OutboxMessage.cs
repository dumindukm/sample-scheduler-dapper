using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Processor.Core.Events
{
    public class OutboxMessage
    {
        public OutboxMessage()
        {

        }
        public OutboxMessage(string messageType , string message)
        {
            Message = message;
            MessageType = messageType;
            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTime.Now;
        }
        public string Id { get; } 
        public string MessageType { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
