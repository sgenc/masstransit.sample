using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LightMessagingCore.Boilerplate.Messaging;
using MassTransit;

namespace LightMessagingCore.Boilerplate.OrderWindowsService
{
    public class OrderCommandFaultConsumer : IConsumer<Fault<IOrderCommand>>
    {
        public Task Consume(ConsumeContext<Fault<IOrderCommand>> context)
        {
            IOrderCommand originalFault = context.Message.Message;
            var exceptions = context.Message.Exceptions;
            var x = context.Message.FaultedMessageId;
            var y = context.Message.FaultId;
            var message = context.Message;

            var exceptionInfo = exceptions.ToList().FirstOrDefault();
            if (exceptionInfo != null)
                File.WriteAllText(@"C:\ConsumeResults\Fault\Result" + Guid.NewGuid().ToString() + "__FaultedMessage.txt", exceptionInfo.Message);

            return Task.FromResult(originalFault);
        }
    }
}