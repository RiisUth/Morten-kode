using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proxies;
using Contracts;

namespace FandomWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductClient proxy = new ProductClient();
            List < ProductData > products = proxy.GetProducts();
            
            txtProductName1.InnerText = products[0].productName;
            txtProductDesription1.InnerText = products[0].productDescription;
            Image1.Height =300;
            Image1.ImageUrl = products[0].imageDatas[0].imagePath;
            Productlink1.HRef = "ProductDetails.aspx?productID=" + products[0].productID.ToString();
            txtProductName2.InnerText = products[1].productName;
            txtProductDesription2.InnerText = products[1].productDescription;
            Image2.ImageUrl = products[1].imageDatas[0].imagePath;
            Image2.AlternateText = products[1].imageDatas[0].productID.ToString();
            Image2.Height = 300;
            productlink2.HRef = "ProductDetails.aspx?productID=" + products[1].productID.ToString();
            txtProductName3.InnerText = products[2].productName;
            txtProductDesription3.InnerText = products[2].productDescription;
            Image3.ImageUrl = products[2].imageDatas[0].imagePath;
            Image3.Height = 300;
            productlink3.HRef = "ProductDetails.aspx?productID=" + products[2].productID.ToString();
        }
            
            
    }
}