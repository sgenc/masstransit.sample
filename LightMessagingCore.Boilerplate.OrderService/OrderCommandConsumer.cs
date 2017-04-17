using System;
using System.IO;
using System.Threading.Tasks;
using LightMessagingCore.Boilerplate.Messaging;
using MassTransit;

namespace LightMessagingCore.Boilerplate.OrderService
{
    public class OrderCommandConsumer : IConsumer<IOrderCommand>
    {
        public async Task Consume(ConsumeContext<IOrderCommand> context)
        {
            //var orderCommand = context.Message;

            //await Console.Out.WriteAsync($"Order code: {orderCommand.OrderCode} Order id: {orderCommand.OrderId}");

           // await Console.Out.WriteAsync($"Order id: {orderCommand.OrderId} "); 

            throw new ArgumentException("Hede test");

            //File.WriteAllText(@"C:\ConsumeResults\Result" + Guid.NewGuid().ToString() + ".txt", context.Message.OrderCode);
            //File.WriteAllText(@"C:\ConsumeResults\Result" + context.Message.OrderId + ".txt", context.Message.OrderCode);

            //do something..
        }
    }
}