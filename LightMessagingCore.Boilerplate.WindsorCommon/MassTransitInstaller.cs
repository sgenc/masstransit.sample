using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using LightMessagingCore.Boilerplate.Common;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace LightMessagingCore.Boilerplate.WindsorCommon
{
    public class MassTransitInstaller :
        IWindsorInstaller
    {
        public void Install(IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            //var busConfig = container.Resolve<BusConfiguration>();

            //var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            //{
            //    var host = cfg.Host(busConfig.HostAddress, h =>
            //    {
            //        h.Username(busConfig.Username);
            //        h.Password(busConfig.Password);
            //    });

            //    sbc.ReceiveEndpoint(busConfig.QueueName, ec =>
            //    {
            //        ec.EnableMessageScope();
            //        ec.LoadFrom(container);
            //    })
            //});

            //container.Release(busConfig);

            //container.Register(Component.For<IBus>().Instance(busControl));
            //container.Register(Component.For<IBusControl>().Instance(busControl));

            //busControl.Start();
        }
    }
}
