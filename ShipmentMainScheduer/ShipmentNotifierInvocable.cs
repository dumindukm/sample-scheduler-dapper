using Coravel.Invocable;
using Shipment.Processor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentMainScheduer
{
    public class ShipmentNotifierInvocable : IInvocable
    {
        private readonly IShipmentNotificationService shipmentNotificationService;

        public ShipmentNotifierInvocable(IShipmentNotificationService shipmentNotificationService)
        {
            this.shipmentNotificationService = shipmentNotificationService;
        }

        public Task Invoke()
        {
            this.shipmentNotificationService.Notify();
            return Task.CompletedTask;
        }
    }
}
