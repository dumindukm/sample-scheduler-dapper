using Shipment.Processor.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Processor.Core.Repository
{
    public interface IOutboxMessageRepository
    {
        public Task<List<OutboxMessage>> GetMessages();
    }
}
