using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract]
   public class OrderData
    {
        [DataMember]
        public int orderID { get; set; }
        [DataMember]
        public DateTime? invoiceDate { get; set;}
        [DataMember]
        public DateTime? invoiceDueDate { get; set; }
        [DataMember]
        public int? paymentID { get; set; }
        [DataMember]
        public int? orderStatusID { get; set; }
        [DataMember]
        public string sessionID { get; set; }
        [DataMember]
        public List<OrderLineData> orderLineDatas { get; set; }

    }
}
