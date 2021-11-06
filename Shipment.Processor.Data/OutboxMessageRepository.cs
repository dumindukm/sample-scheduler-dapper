using Dapper;
using Shipment.Processor.Core.Events;
using Shipment.Processor.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Processor.Data
{
    public class OutboxMessageRepository : IOutboxMessageRepository
    {
        private ShipmentDataContext context;
        public OutboxMessageRepository(ShipmentDataContext context)
        {
            this.context = context;
        }
        public async Task<List<OutboxMessage>> GetMessages()
        {
            var query = "SELECT * FROM OutBoxMessages";
            using (var connection = context.CreateConnection())
            {
                try
                {
                    var messages = await connection.QueryAsync<OutboxMessage>(query);
                    return messages.ToList();
                }
                catch(Exception ex)
                {

                }
                return null;
            }
        }
    }
}
