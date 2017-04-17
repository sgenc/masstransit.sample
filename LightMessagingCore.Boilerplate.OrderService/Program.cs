using System;
using LightMessagingCore.Boilerplate.Common;
using System.Configuration;
using GreenPipes;
using MassTransit;

namespace LightMessagingCore.Boilerplate.OrderService
{
    class Program
    {
        private static IBusControl bus;

        static void Main(string[] args)
        {
            Console.Title = "OrderService";

            try
            {
                if (bus == null)
                {
                    bus = BusConfigurator.Instance
                       //.UseRetry(Retry.Immediate(2))
                       .ConfigureBus((cfg, host) =>
                       {
                           cfg.ReceiveEndpoint(host, ConfigurationManager.AppSettings["OrderQueueName"], e =>
                           {
                               e.Consumer<OrderCommandConsumer>();
                           });


                           //cfg.ReceiveEndpoint(host, "lightmessagingcore.boilerplate.order_error", conf =>
                           //{
                           //    conf.Consumer<OrderCommandFaultConsumer>();
                           //});
                       });

                    bus.Start();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured : " +  ex.Message);
                
            }

            Console.WriteLine("Listening order command..");

        }
    }
}