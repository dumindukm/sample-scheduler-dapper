using Coravel.Invocable;
using Shipment.Processor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentMainScheduer
{
    class ShipmentReaderInvocable : IInvocable
    {
        IShipmentReader _reader;
        public ShipmentReaderInvocable(IShipmentReader reader)
        {
            _reader = reader;
        }
        public Task Invoke()
        {
            _reader.Read();
            return Task.CompletedTask;
        }
    }
}
