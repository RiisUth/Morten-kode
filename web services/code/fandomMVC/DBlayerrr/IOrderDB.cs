using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBlayerrr
{
        public interface IOrderDB
    {
        void insertOrder(Order order);
        void updateOrder(Order order);
        void deleteOrder(Order order);
        Order findOrderById(int id);
        IEnumerable<Order> OrdersByProductId(int id);
        Order findorderBySession(string session);

        void compeletOrder(int id);
    }
}
