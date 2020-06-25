using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Contracts
{
    [ServiceContract]
    public interface IOrderlineService
    {
        [OperationContract]
        void InsertOrderLine(OrderLineData orderline);
        [OperationContract]
        void insertOrderLines(IEnumerable<OrderLineData> orderline);
        [OperationContract]
        void deleteOrderLine(OrderLineData orderline);
        [OperationContract]
        void UpdateOrderLine(OrderLineData orderline);
        [OperationContract]
        List<OrderLineData> findOrderLinesByProductID(int productID);
        [OperationContract]
        List<OrderLineData> findorderLineByOrderId(int orderID);
      
            


 
    }
}
