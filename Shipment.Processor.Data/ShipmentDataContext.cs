using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data;

namespace Shipment.Processor.Data
{
    public class ShipmentDataContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ShipmentDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection_lite");
        }

        public IDbConnection CreateConnection()
            => new SqliteConnection(_connectionString);
    }
}
