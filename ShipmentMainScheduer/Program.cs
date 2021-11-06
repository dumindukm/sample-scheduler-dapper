using Coravel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shipment.Processor.Core.Interfaces;
using Shipment.Processor.Core.Services;
using System;
using System.IO;
using MediatR;
using System.Reflection;
using Shipment.Processor.Core.Extensions;
using Shipment.Processor.Data;
using Shipment.Processor.Core.Repository;

namespace ShipmentMainScheduer
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    configApp.SetBasePath(Directory.GetCurrentDirectory());
                    configApp.AddEnvironmentVariables(prefix: "PREFIX_");
                    configApp.AddJsonFile("appsettings.json");
                    configApp.AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    // Add Coravel's Scheduling...
                    services.AddScheduler();
                    services.AddSingleton<IShipmentReader, ShipmentFtpReader>();
                    services.AddSingleton<ShipmentReaderInvocable>();
                    services.AddSingleton<ShipmentNotifierInvocable>();
                    services.AddSingleton<IShipmentNotificationService, ShipmentNotificationService>();
                    services.AddSingleton<ShipmentDataContext>();
                    services.AddSingleton<IOutboxMessageRepository, OutboxMessageRepository>();
                    CoreDependencyExtension.AddApplicationCorDependencies(services);

                })
                .Build();


            // Configure the scheduled tasks....
            host.Services.UseScheduler(scheduler =>
                {
                    //scheduler
                    //.Schedule<ShipmentReaderInvocable>()
                    //.EverySeconds(5);

                    scheduler
                       .Schedule<ShipmentNotifierInvocable>()
                       .EverySeconds(5);

                }
            );

            // Run it!
            host.Run();
        }
    }
}
