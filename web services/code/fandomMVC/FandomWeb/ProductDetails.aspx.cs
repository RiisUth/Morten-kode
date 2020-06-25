using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proxies;
using Contracts;
using System.Web.ModelBinding;

namespace FandomWeb
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public ProductData GetProduct([QueryString("productID")] int? productID)
        {
            
            ProductClient proxy = new ProductClient();
            ProductData data = new ProductData();
            if(productID.HasValue && productID > 0)
            {
               int dataID= productID.Value;
                data = proxy.GetProductByID(dataID);
            }
            else
            {
                data = null;
            }
            return data;
        }
    }
}