using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using DBlayerrr;

namespace Contracts
{
    [DataContract]
    public class ProductData
    {
        [DataMember]
        public double price { get; set; }
        [DataMember]
        public int productID { get; set; }
        [DataMember]
        public string productName { get; set; }
        [DataMember]
        public string productDescription { get; set; }
        [DataMember]
        public int? supplierID { get; set; }
        [DataMember]
        public int? quantity { get; set; }
        [DataMember]
        public bool? viasble { get; set; }
        [DataMember]
        public List<ImageData> imageDatas { get; set; }
        [DataMember]
        public string mainImgSrc { get; set; }
        
    }
}

