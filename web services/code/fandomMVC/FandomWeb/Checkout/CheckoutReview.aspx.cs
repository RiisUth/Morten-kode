using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contracts;
using Proxies;
using FandomWeb.Logic;
using Nest;

namespace FandomWeb.Checkout
{
    public partial class CheckoutReview : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<CartItemData> areyousuposetobehere = null;
                string session;

                using (ShoppingcartActions usersShoppingCart = new ShoppingcartActions())
                {
                    areyousuposetobehere = usersShoppingCart.GetCartItems();
                    session = usersShoppingCart.GetCartId();
                }
                if (areyousuposetobehere.Count >0)
                {
                    OrderData orderData = new OrderData();

                    // Get DB context.
                    OrderClient orderProxy = new OrderClient();
                    OrderLineClient orderLineProxy = new OrderLineClient();
                    ProductClient productProxy = new ProductClient();
                    CartItemClient cartItemProxy = new CartItemClient();

                    orderData.orderStatusID = 1;
                    orderData.invoiceDueDate = DateTime.Now.AddDays(30);
                    orderData.invoiceDate = DateTime.Now;
                    orderData.orderLineDatas = new List<OrderLineData>();

                    orderData.sessionID = session;
                    orderProxy.InsertOrder(orderData);
                        // Add order to DB.
                    


                    // Get the shopping cart items and process them.
                    using (ShoppingcartActions usersShoppingCart = new  ShoppingcartActions())
                    {
                        OrderData myOrder = new OrderData();
                        myOrder = orderProxy.FindOrderBySesionId(usersShoppingCart.GetCartId());
                        List<CartItemData> myOrderList = usersShoppingCart.GetCartItems();
                        double total = new double();

                        // Add OrderDetail information to the DB for each product purchased.
                        for (int i = 0; i < myOrderList.Count; i++)
                        {
                            // Create a new OrderDetail object.
                            var myOrderDetail = new OrderLineData();
                            myOrderDetail.OrderId = myOrder.orderID;
                            myOrderDetail.productId = myOrderList[i].ProductID;
                            myOrderDetail.amount = myOrderList[i].quantity;
                            myOrderDetail.price = myOrderList[i].Product.price * myOrderDetail.amount;
                            total = total + myOrderDetail.price;

                            // Add OrderDetail to DB.
                            myOrder.orderLineDatas.Add(myOrderDetail);
                            
                        }

                        // add to db

                        orderLineProxy.insertOrderLines(myOrder.orderLineDatas);

                        // Display Order information.
                        List<OrderData> orderList = new List<OrderData>();
                        orderList.Add(myOrder);
                        

                        // Display OrderDetails.
                        OrderItemList.DataSource = myOrderList;
                        OrderItemList.DataBind();
                        Total.Text = total.ToString();
                    }
                }
                else
                {
                    Response.Redirect("CheckoutError.aspx?" );
                }
            }
        }

        protected void CheckoutConfirm_Click(object sender, EventArgs e)
        {
            if(CBagreementOFTermsOfServies.Checked == true)
            {
                Response.Redirect("CheckoutComplete.aspx");
            }
            
        }
    }
}