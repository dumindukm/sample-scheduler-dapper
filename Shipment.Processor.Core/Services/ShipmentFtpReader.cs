using Shipment.Processor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Processor.Core.Services
{
    public class ShipmentFtpReader : IShipmentReader
    {
        public void Read()
        {
            System.Console.WriteLine("In shipment reader");
        }
    }
}
