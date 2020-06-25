using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace Contracts
{
    [DataContract]
    public class CartItemData
    {
        [DataMember]
        public int cartItemID { get; set; }
        [DataMember]
        public string seassionID { get; set; }
        [DataMember]
        public int quantity { get; set; }
        [DataMember]
        public DateTime? createdDate { get; set; }
        [DataMember]
        public ProductData Product { get; set; }
        [DataMember]
        public int? ProductID { get; set; }
    }
}
