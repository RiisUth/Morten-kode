using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Contracts
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        void InsertOrder(OrderData order);

        [OperationContract]
        void updateOrder(OrderData order);
        [OperationContract]
        void deleteOrder(OrderData order);
        [OperationContract]
        OrderData findOrderById(int id);
        [OperationContract]
        OrderData FindOrderBySesionId(string sessionID);
        [OperationContract]
        void completOrder(int id);
    }
}
