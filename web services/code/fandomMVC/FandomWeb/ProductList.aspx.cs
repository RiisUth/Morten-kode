using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contracts;
using Proxies;

namespace FandomWeb
{

    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<ProductData> GetProducts()
        {
            ProductClient proxy = new ProductClient();
            return proxy.GetProducts();

        }

        public string getImgPath(int id)
        {
            return null;
        }
    }
}