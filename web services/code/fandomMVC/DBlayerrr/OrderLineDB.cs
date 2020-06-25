using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBlayerrr
{
    public class OrderLineDB : IOrderLineDB
    {
        fandomDBDataContext db = new fandomDBDataContext();
        public void deleteOrderLine(OrderLine orderLine)
        {
            db.OrderLines.DeleteOnSubmit(orderLine);
            db.SubmitChanges();
        }

        public OrderLine FindOrderLineByID(int orderlineid)
        {
            var orderLines = db.OrderLines;
            var orderLine = (from o in orderLines where o.orderLineID == orderlineid select o).SingleOrDefault();
            return orderLine;
            
        }

        public IEnumerable<OrderLine> findOrderLineByOrderID(int orderId)
        {
            var orderLines = db.OrderLines;
            var orderline = (from o in orderLines where o.orderID == orderId select o).AsEnumerable();
            return orderline;
        }

        public IEnumerable<OrderLine> findOrderLinesByProductID(int productId)
        {
            var orderlines = db.OrderLines;
            var orderline = (from o in orderlines where o.orderLineID == productId select o).AsEnumerable();
            return orderline;
        }

        public void insertOrderLine(OrderLine orderLine)
        {
            db.OrderLines.InsertOnSubmit(orderLine);
            db.SubmitChanges();
        }

        public void insertOrderLines(IEnumerable<OrderLine> orderLines)
        {
            using (db)
            {
                db.OrderLines.InsertAllOnSubmit(orderLines);
                db.SubmitChanges();
            }
        }

        public void updateOrderLine(OrderLine orderLine)
        {
            var OrderLine1 = db.OrderLines.SingleOrDefault(o => o.orderLineID == orderLine.orderLineID);

            OrderLine1.amount = orderLine.amount;
            OrderLine1.price = orderLine.amount * orderLine.Product.price;
            OrderLine1.lineText = orderLine.lineText;
            db.SubmitChanges();

            
        }
    }
}
