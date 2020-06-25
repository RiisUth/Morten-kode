using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Contracts;
using System.Threading.Tasks;
using Services;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost HostProductService1 = new ServiceHost(typeof(ProductServices));
            HostProductService1.Open();

            ServiceHost HostOrderService = new ServiceHost(typeof(OrderService));
            HostOrderService.Open();

            ServiceHost HostOrderLineService = new ServiceHost(typeof(OrderLineService));
            HostOrderLineService.Open();

            ServiceHost HostCartItemService = new ServiceHost(typeof(CartItemService));
            HostCartItemService.Open();

            Console.WriteLine("Services started. Press [Enter] to exit.");
            Console.ReadLine();

            HostProductService1.Close();
            HostCartItemService.Close();
            HostOrderService.Close();
            HostOrderLineService.Close();
        }
    }
}
