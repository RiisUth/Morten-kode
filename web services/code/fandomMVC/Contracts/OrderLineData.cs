using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract]
   public class OrderLineData
    {
        [DataMember]
        public int OrderLineId { get; set; }
        [DataMember]
        public int? OrderId { get; set; }
        [DataMember]
        public int amount { get; set; }
        [DataMember]
        public double price { get; set; }
        [DataMember]
        public String lineText { get; set; }
        [DataMember]
        public int? productId { get; set; }
        
    }
}
