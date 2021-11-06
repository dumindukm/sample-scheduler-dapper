using Microsoft.Extensions.DependencyInjection;
using Shipment.Processor.Core.NotificationHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Reflection;

namespace Shipment.Processor.Core.Extensions
{
    public static class CoreDependencyExtension
    {
        public static IServiceCollection AddApplicationCorDependencies(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
