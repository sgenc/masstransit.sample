using System;
using System.Configuration;
using System.Web.Mvc;
using LightMessagingCore.Boilerplate.Common;
using LightMessagingCore.Boilerplate.OrderUI.Models;
using MassTransit;

namespace LightMessagingCore.Boilerplate.OrderUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly ISendEndpoint _bus;

        //private readonly IBusControl _busControl;

        private static IBusControl _busControl;

        public OrderController()
        {
            if(_busControl == null)
                _busControl = BusConfigurator.Instance.ConfigureBus();

            //var _busControl = BusConfigurator.Instance.ConfigureBus();
            var sendToUri = new Uri($"{MqConstants.RabbitMQUri}{ConfigurationManager.AppSettings["OrderQueueName"]}");

            _bus = _busControl.GetSendEndpoint(sendToUri).Result;
        }

        // GET: Order
        public ActionResult Index(OrderModel orderModel)
        {
            if (orderModel.OrderId > 0)
                CreateOrder(orderModel);

            return View();
        }

        private void CreateOrder(OrderModel orderModel)
        {
            _bus.Send(orderModel,s=> s.FaultAddress = new Uri(MqConstants.RabbitMQUri + "lightmessagingcore.boilerplate.order_error"));
        }
    }
}