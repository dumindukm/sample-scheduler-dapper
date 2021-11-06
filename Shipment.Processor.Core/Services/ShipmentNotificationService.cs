using MediatR;
using Shipment.Processor.Core.Events;
using Shipment.Processor.Core.Interfaces;
using Shipment.Processor.Core.NotificationHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Shipment.Processor.Core.Repository;

namespace Shipment.Processor.Core.Services
{
    public class ShipmentNotificationService : IShipmentNotificationService
    {
        private readonly IMediator mediator;
        private readonly IOutboxMessageRepository outboxRepository;

        public ShipmentNotificationService(IMediator mediator , IOutboxMessageRepository outboxRepository)
        {
            this.mediator = mediator;
            this.outboxRepository = outboxRepository;
        }
        public async void Notify()
        {
            System.Console.WriteLine("In shipment notification service");
            //List<OutboxMessage> outBoxMessages = new List<OutboxMessage>();
            //OutboxMessage outboxMessage = new OutboxMessage(typeof(ShipmentConfirmedEvent).AssemblyQualifiedName, JsonSerializer.Serialize(new ShipmentConfirmedEvent("shipmemnt comfr")));
            //outBoxMessages.Add(outboxMessage);

            var outBoxMessages = await outboxRepository.GetMessages();

            foreach (var message in outBoxMessages)
            {
                // for broad cast use INotificationHandler in hndler class
                //this.mediator.Publish(JsonSerializer.Deserialize(message.Message, Type.GetType(message.MessageType)));

                await this.mediator.Send(JsonSerializer.Deserialize(message.Message, Type.GetType(message.MessageType)));
            }



        }
    }
}
