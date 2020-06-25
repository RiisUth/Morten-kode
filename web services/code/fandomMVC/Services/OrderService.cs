using Contracts;
using DBlayerrr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services 
{
  public  class OrderService : IOrderService
       
    {
        IOrderDB _OrderDB = null;

        public void completOrder(int id)
        {
            IOrderDB orderDB = _OrderDB ?? new OrderDB();

            orderDB.compeletOrder(id);
        }

        public void deleteOrder(OrderData order)
        {
            IOrderDB orderDB = _OrderDB ?? new OrderDB();
            IOrderLineDB orderLineDB = new OrderLineDB();
            Order deleteOrder = new Order();
            Order check = orderDB.findOrderById(order.orderID);
        if (order != null && check != null)
            {
                deleteOrder.orderID = order.orderID;
                deleteOrder.invoiceDate = order.invoiceDate;
                deleteOrder.invoiceDueDate = order.invoiceDueDate;
                deleteOrder.paymentID = order.paymentID;
                deleteOrder.orderStatusID = order.orderStatusID;
                // need refactoring
                deleteOrder.OrderLines = new System.Data.Linq.EntitySet<OrderLine>();
                foreach (var item in order.orderLineDatas)
                {
                    OrderLine orderLine = new OrderLine();
                    orderLine.orderLineID = item.OrderLineId;
                    orderLine.orderID = deleteOrder.orderID;
                    orderLine.amount = item.amount;
                    orderLine.price = item.price;
                    orderLine.lineText = item.lineText;
                    orderLine.productID = item.productId;
                    deleteOrder.OrderLines.Add(orderLine);
                }
                orderDB.deleteOrder(deleteOrder);

            }
        
        }

        public OrderData findOrderById(int id)
        {
            IOrderlineService orderlineService = new OrderLineService();
            OrderData orderdata = null;
            IOrderDB orderDB = _OrderDB ?? new OrderDB();
            Order orderEntity = orderDB.findOrderById(id);
            if (orderEntity != null)
            {
                orderdata = new OrderData();
                orderdata.orderID = orderEntity.orderID;
                orderdata.invoiceDate = orderEntity.invoiceDate;
                orderdata.invoiceDueDate = orderEntity.invoiceDueDate;
                orderdata.paymentID = orderEntity.paymentID;
                orderdata.orderStatusID = orderEntity.orderStatusID;
                orderdata.sessionID = orderEntity.sessionID;
                orderdata.orderLineDatas = orderlineService.findorderLineByOrderId(id);
            }
            return orderdata;
        }

        public OrderData FindOrderBySesionId(string sessionID)
        {
            IOrderlineService orderlineService = new OrderLineService();
            OrderData orderdata = null;
            IOrderDB orderDB = _OrderDB ?? new OrderDB();
            Order orderEntity = orderDB.findorderBySession(sessionID);
            if (orderEntity != null)
            {
                orderdata = new OrderData();
                orderdata.orderID = orderEntity.orderID;
                orderdata.invoiceDate = orderEntity.invoiceDate;
                orderdata.invoiceDueDate = orderEntity.invoiceDueDate;
                orderdata.paymentID = orderEntity.paymentID;
                orderdata.orderStatusID = orderEntity.orderStatusID;
                orderdata.sessionID = orderEntity.sessionID;
                orderdata.orderLineDatas = orderlineService.findorderLineByOrderId(orderdata.orderID);
            }
            return orderdata;
        }

        public void InsertOrder(OrderData order)
        {
            IOrderDB orderDB = _OrderDB ?? new OrderDB();
            Order insertOrder = new Order();
            Order check = orderDB.findOrderById(order.orderID);
            if (order != null && check == null)
            {
                insertOrder.orderID = order.orderID;
                insertOrder.invoiceDate = order.invoiceDate;
                insertOrder.invoiceDueDate = order.invoiceDueDate;
                insertOrder.paymentID = order.paymentID;
                insertOrder.orderStatusID = order.orderStatusID;
                insertOrder.sessionID = order.sessionID;
                // need refactoring
                insertOrder.OrderLines = new System.Data.Linq.EntitySet<OrderLine>();
                foreach (var item in order.orderLineDatas)
                {
                    OrderLine orderLine = new OrderLine();
                    orderLine.orderLineID = item.OrderLineId;
                    orderLine.orderID = insertOrder.orderID;
                    orderLine.amount = item.amount;
                    orderLine.price = item.price;
                    orderLine.lineText = item.lineText;
                    orderLine.productID = item.productId;
                    insertOrder.OrderLines.Add(orderLine);
                }
                orderDB.insertOrder(insertOrder);
            }
        }

        public void updateOrder(OrderData order)
        {
            IOrderDB orderDB = _OrderDB ?? new OrderDB();
            Order updateOrder = new Order();
            Order check = orderDB.findOrderById(order.orderID);
            if (order != null && check == null)
            {
                updateOrder.orderID = order.orderID;
                updateOrder.invoiceDate = order.invoiceDate;
                updateOrder.invoiceDueDate = order.invoiceDueDate;
                updateOrder.paymentID = order.paymentID;
                updateOrder.orderStatusID = order.orderStatusID;
                // need refactoring
                orderDB.updateOrder(updateOrder);
            }

        }
    }
}
