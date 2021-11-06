using MediatR;
using Shipment.Processor.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shipment.Processor.Core.NotificationHandlers
{

    public class TmsNotificationHandler : IRequestHandler<ShipmentConfirmedEvent>//INotificationHandler<ShipmentConfirmedEvent>
    {
        /// this is for broad cast message handler
        //public Task Handle(ShipmentConfirmedEvent notification, CancellationToken cancellationToken)
        //{
        //    System.Console.WriteLine("in tms" + notification.Message);

        //    return Task.CompletedTask;
        //}
        public async Task<Unit> Handle(ShipmentConfirmedEvent request, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("in tms" + request.Message);

            return Unit.Value;

        }
    }
}
