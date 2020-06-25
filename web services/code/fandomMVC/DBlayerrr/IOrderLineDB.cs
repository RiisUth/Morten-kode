using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBlayerrr
{
    public interface IOrderLineDB
    {
        void insertOrderLine(OrderLine orderLine);
        void insertOrderLines(IEnumerable<OrderLine> orderLines);
        void updateOrderLine(OrderLine orderLine);
        void deleteOrderLine(OrderLine orderLine);
        OrderLine FindOrderLineByID(int orderlineid);
        IEnumerable<OrderLine> findOrderLinesByProductID(int productId);
        IEnumerable<OrderLine> findOrderLineByOrderID(int orderId);


    }
}
