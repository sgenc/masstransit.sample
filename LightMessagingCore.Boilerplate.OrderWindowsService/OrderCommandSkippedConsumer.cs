using System;
using System.IO;
using System.Threading.Tasks;
using LightMessagingCore.Boilerplate.Messaging;
using MassTransit;

namespace LightMessagingCore.Boilerplate.OrderWindowsService
{
    public class OrderCommandSkippedConsumer : IConsumer<IOrderCommand>
    {
        public async Task Consume(ConsumeContext<IOrderCommand> context)
        {
            var orderCommand = context.Message;

            File.WriteAllText(@"C:\ConsumeResults\Skipped\Result" + Guid.NewGuid().ToString() + "__SkippedMessage.txt", context.Message.OrderCode);

            //await Console.Out.WriteAsync($"Order code: {orderCommand.OrderCode} Order id: {orderCommand.OrderId}");

            //await Console.Out.WriteAsync($"Order id: {orderCommand.OrderId} "); 

            //File.WriteAllText(@"C:\ConsumeResults\Result" + Guid.NewGuid().ToString() + ".txt", context.Message.OrderCode);
            //File.WriteAllText(@"C:\ConsumeResults\Result" + context.Message.OrderId + ".txt", context.Message.OrderCode);

            //do something..

        }
    }
}