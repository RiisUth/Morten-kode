using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Contracts
{
    [DataContract]
    public class ImageData
    {
        [DataMember]
        public int imgID { get; set; }
        [DataMember]
        public  string imagePath { get; set; }
        [DataMember]
        public int productID { get; set; }

    }
}
