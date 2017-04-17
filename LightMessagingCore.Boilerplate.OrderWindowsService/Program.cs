using System;
using System.Timers;
using LightMessagingCore.Boilerplate.Common;
using MassTransit;
using Topshelf;

namespace LightMessagingCore.Boilerplate.OrderWindowsService
{
    public class EventConsumerService : ServiceControl
    {
        private IBusControl bus;

        public IBusControl ConfigureBus()
        {
            return  BusConfigurator.Instance
               .UseRetry(Retry.Immediate(1))
               .ConfigureBus((cfg, host) =>
               {
                   cfg.ReceiveEndpoint(host, "lightmessagingcore.boilerplate.order", e =>
                   {
                       e.Consumer<OrderCommandConsumer>();
                   });

                   cfg.ReceiveEndpoint(host, "lightmessagingcore.boilerplate.order_error", conf =>
                   {
                       conf.Consumer<OrderCommandFaultConsumer>();
                   });

                   cfg.ReceiveEndpoint(host, "lightmessagingcore.boilerplate.order_error_skipped", conf =>
                   {
                       conf.Consumer<OrderCommandSkippedConsumer>();
                   });
               });
        }

        public bool Start(HostControl hostControl)
        {
            bus = ConfigureBus();
            bus.Start();

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            bus?.Stop(TimeSpan.FromSeconds(30));
            return true;
        }
    }

    public class Program
    {
        public static void Main()
        {
            //HostFactory.Run(cfg => //1
            //    cfg.Service(
            //        x => new EventConsumerService())

            //        );


            HostFactory.Run(config =>
            {
                config.Service<EventConsumerService>();
                config.SetServiceName("LightMessagingCore.Boilerplate.OrderWindowsService2");
            });

            //HostFactory.Run(config =>
            //{
            //    config.Service<EventConsumerService>();
            //    config.SetServiceName("LightMessagingCore.Boilerplate.OrderWindowsService");
            //});
        }


    }
}
