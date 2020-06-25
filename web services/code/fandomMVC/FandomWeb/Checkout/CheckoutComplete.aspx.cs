using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contracts; 
using Proxies;
using System.Data.Linq;
using System.ServiceModel;

namespace FandomWeb.Checkout
{
    public partial class CheckoutComplete : System.Web.UI.Page
    {
        int tries;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                    {
                    
                    OrderLineClient orderLineClient = new OrderLineClient();
                        ProductClient productproxy = new ProductClient();
                        OrderClient orderProxy = new OrderClient();

                    using (FandomWeb.Logic.ShoppingcartActions usersShoppingCart =
                            new FandomWeb.Logic.ShoppingcartActions())
                        {
                            string PaymentConfirmation = usersShoppingCart.GetCartId();


                            TransactionId.Text = PaymentConfirmation;
                        }


                    using (FandomWeb.Logic.ShoppingcartActions usersShoppingCart =
                        new FandomWeb.Logic.ShoppingcartActions())
                    {

                        List<CartItemData> cart;
                        cart = usersShoppingCart.GetCartItems();
                        string currentOrderId = usersShoppingCart.GetCartId();

                        if (cart.Count > 0)
                        {
                            try
                            {

                                OrderData myCurrentOrder;
                                myCurrentOrder = orderProxy.FindOrderBySesionId(currentOrderId);

                                orderProxy.completOrder(myCurrentOrder.orderID);
                                //foreach (var item in myCurrentOrder.orderLineDatas)
                                //{
                                //    ProductData product = new ProductData();
                                //    product = productproxy.GetProductByID(int.Parse(item.productId.ToString()));
                                //    product.quantity = product.quantity - item.amount;
                                //    if (product.quantity <= -1)
                                //    {
                                //        string msg = "there is no more products";
                                //        throw new Exceptions.NoMoreProductsException(msg);
                                //    }
                                    
                                //}
                                //foreach (var item in myCurrentOrder.orderLineDatas)
                                //{
                                //    ProductData product = new ProductData();
                                //    product = productproxy.GetProductByID(int.Parse(item.productId.ToString()));
                                //    product.quantity = product.quantity - item.amount;
                                //    productproxy.MinusProductQuantity(product.productID, int.Parse(product.quantity.ToString()));
                                //}
                                //orderProxy.updateOrder(myCurrentOrder);

                                // Clear shopping cart.

                                usersShoppingCart.EmptyCart();

                            }
                            catch (Exceptions.NoMoreProductsException)
                            {
                                Response.Redirect("CheckoutError.aspx?");
                            }
                            catch (FaultException)
                            {

                                tries++;
                                if(tries <= 11)
                                {
                                    UpdateOrder();
                                }
                                else
                                {
                                    Response.Redirect("CheckoutError.aspx?");
                                }
                                
                            }
                             }
                            else
                            {
                                Response.Redirect("CheckoutError.aspx?");
                            }
                        }
                       
                 //   }
                    }
               
            }
    }

        private void UpdateOrder()
        {
            tries++;
            try { 
            using (FandomWeb.Logic.ShoppingcartActions usersShoppingCart =
                            new FandomWeb.Logic.ShoppingcartActions())
            {
                 OrderClient orderProxy = new OrderClient();
                    string currentOrderId = usersShoppingCart.GetCartId();
                //    OrderLineClient orderLineClient = new OrderLineClient();
                //    ProductClient productproxy = new ProductClient();
                //    OrderClient orderProxy = new OrderClient();
                   OrderData myCurrentOrder;
                   myCurrentOrder = orderProxy.FindOrderBySesionId(currentOrderId);
                  orderProxy.completOrder(myCurrentOrder.orderID);
                //    // Update the order to reflect payment has been completed.
                //    myCurrentOrder.orderStatusID = 3;

                //    foreach (var item in myCurrentOrder.orderLineDatas)
                //    {
                //        ProductData product = new ProductData();
                //        product = productproxy.GetProductByID(int.Parse(item.productId.ToString()));
                //        product.quantity = product.quantity - item.amount;
                //        if (product.quantity <= -1)
                //        {
                //            string msg = "there is no more products";
                //            throw new Exceptions.NoMoreProductsException(msg);
                //        }

                //        productproxy.MinusProductQuantity(product.productID, int.Parse(item.amount.ToString()));
                //    }
                //    orderProxy.updateOrder(myCurrentOrder);

                // Clear shopping cart.
             
                usersShoppingCart.EmptyCart();
            }
            }
            catch (FaultException)
            {

                tries++;
                if (tries <= 11)
                {
                    UpdateOrder();
                }
                else
                {
                    Response.Redirect("CheckoutError.aspx?");
                }

            }
        }

        protected void Continue_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Default");
        }
    }
}