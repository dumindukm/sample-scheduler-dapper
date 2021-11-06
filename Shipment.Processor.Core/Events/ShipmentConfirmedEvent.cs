using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Processor.Core.Events
{
    public class ShipmentConfirmedEvent : IRequest // INotification
    {
        public ShipmentConfirmedEvent(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

}
