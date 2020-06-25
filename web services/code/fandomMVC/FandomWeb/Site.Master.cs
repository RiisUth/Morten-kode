using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using FandomWeb.Logic;
using System.Web.UI.WebControls;

namespace FandomWeb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (ShoppingcartActions usersShoppingCart = new ShoppingcartActions())
            {
                string cartStr = string.Format("Cart ({0})", usersShoppingCart.GetCount());
              //  cartCount.InnerText = cartStr;
            }
        }
    }
}