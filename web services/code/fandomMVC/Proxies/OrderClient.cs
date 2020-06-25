using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Proxies
{

     public class OrderClient : ClientBase<IOrderService>, IOrderService
    {
        public void completOrder(int id)
        {
            Channel.completOrder(id);
        }

        public void deleteOrder(OrderData order)
        {
            Channel.deleteOrder(order);
        }

        public OrderData findOrderById(int id)
        {
            return Channel.findOrderById(id);
        }

        public OrderData FindOrderBySesionId(string sessionID)
        {
            return Channel.FindOrderBySesionId(sessionID);
        }

        public void InsertOrder(OrderData order)
        {
            Channel.InsertOrder(order);
        }

        public void updateOrder(OrderData order)
        {
            Channel.updateOrder(order);
        }
    }
}
