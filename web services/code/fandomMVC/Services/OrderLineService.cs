using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DBlayerrr;
namespace Services
{
    public class OrderLineService : IOrderlineService
    {
        
        IOrderLineDB _orderLineDB = null;

        public void deleteOrderLine(OrderLineData orderline)
        {
            IOrderLineDB orderLineDB = _orderLineDB ?? new OrderLineDB();
            OrderLine deleteOrderLine = new OrderLine();
            OrderLine check = orderLineDB.FindOrderLineByID(orderline.OrderLineId);
            if (orderline != null && check != null)
            {
                deleteOrderLine.orderLineID = orderline.OrderLineId;
                deleteOrderLine.orderID = orderline.OrderId;
                deleteOrderLine.amount = orderline.amount;
                deleteOrderLine.price = orderline.price;
                deleteOrderLine.lineText = orderline.lineText;
                deleteOrderLine.productID = orderline.productId;
                orderLineDB.deleteOrderLine(deleteOrderLine);
            }
            
        }

        public List<OrderLineData> findorderLineByOrderId(int orderID)
        {
            IOrderLineDB orderLineDB = _orderLineDB ?? new OrderLineDB();
            IEnumerable<OrderLine> check = orderLineDB.findOrderLineByOrderID(orderID);
            List<OrderLineData> orderLines = new List<OrderLineData>(); 
            if (check != null)
            {
                foreach (var orderline in check)
                {
                    OrderLineData orderlinedata = new OrderLineData();
                    orderlinedata.OrderLineId = orderline.orderLineID;
                    orderlinedata.OrderId = orderline.orderID;
                    orderlinedata.amount = orderline.amount;
                    orderlinedata.price = orderline.price;
                    orderlinedata.lineText = orderline.lineText;
                    orderlinedata.productId = orderline.productID;
                    orderLines.Add(orderlinedata);
                }
            }
            return orderLines;
        }

        public List<OrderLineData> findOrderLinesByProductID(int productID)
        {
            IOrderLineDB orderLineDB = _orderLineDB ?? new OrderLineDB();
            IEnumerable<OrderLine> check = orderLineDB.findOrderLineByOrderID(productID);
            List<OrderLineData> orderLines = new List<OrderLineData>();
            if (check != null)
            {
                foreach (var orderline in check)
                {
                    OrderLineData orderlinedata = new OrderLineData();
                    orderlinedata.OrderLineId = orderline.orderLineID;
                    orderlinedata.OrderId = orderline.orderID;
                    orderlinedata.amount = orderline.amount;
                    orderlinedata.price = orderline.price;
                    orderlinedata.lineText = orderline.lineText;
                    orderlinedata.productId = orderline.productID;
                    orderLines.Add(orderlinedata);
                }
            }
            return orderLines;
        }

        public void InsertOrderLine(OrderLineData orderline)
        {
            IOrderLineDB orderLineDB = _orderLineDB ?? new OrderLineDB();
            OrderLine InsertOrderLine = new OrderLine();
            OrderLine check = orderLineDB.FindOrderLineByID(orderline.OrderLineId);
        if(check != null)
            {
                InsertOrderLine.orderLineID = orderline.OrderLineId;
                InsertOrderLine.orderID = orderline.OrderId;
                InsertOrderLine.amount = orderline.amount;
                InsertOrderLine.price = orderline.price;
                InsertOrderLine.lineText = orderline.lineText;
                InsertOrderLine.productID = orderline.productId;

                orderLineDB.insertOrderLine(InsertOrderLine);
            }
        }

        public void insertOrderLines(IEnumerable<OrderLineData> orderline)
        {
            IOrderLineDB orderLineDB = _orderLineDB ?? new OrderLineDB();
            List<OrderLine> orderlines = new List<OrderLine>();
            if( orderline != null)
            {
                foreach (OrderLineData orderLineData in orderline)
                {
                    OrderLine insertingOrderLine = new OrderLine();
                    insertingOrderLine.orderLineID = orderLineData.OrderLineId;
                    insertingOrderLine.orderID = orderLineData.OrderId;
                    insertingOrderLine.amount = orderLineData.amount;
                    insertingOrderLine.price = orderLineData.price;
                    insertingOrderLine.lineText = orderLineData.lineText;
                    insertingOrderLine.productID = orderLineData.productId;
                    orderlines.Add(insertingOrderLine); 
                    
                
                }
                    orderLineDB.insertOrderLines(orderlines);
            }
        }

        public void UpdateOrderLine(OrderLineData orderline)
        {
            IOrderLineDB orderLineDB = _orderLineDB ?? new OrderLineDB();
            OrderLine updateOrderLine = new OrderLine();
            OrderLine check = orderLineDB.FindOrderLineByID(orderline.OrderLineId);
            if (orderline != null && check != null)
            {
                updateOrderLine.orderLineID = orderline.OrderLineId;
                updateOrderLine.orderID = orderline.OrderId;
                updateOrderLine.amount = orderline.amount;
                updateOrderLine.price = orderline.price;
                updateOrderLine.lineText = orderline.lineText;
                updateOrderLine.productID = orderline.productId;
                orderLineDB.updateOrderLine(updateOrderLine);
            }
        }
    }
}
