using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proxies;
using Contracts;
namespace FandomWeb.Logic
{
    public class ShoppingcartActions : IDisposable
    {
        public string ShoppingCartID { get; set; }

        private ProductClient Productproxy = new ProductClient();
        private CartItemClient CartitemProxy = new CartItemClient();
        public const string CartSessionKey = "CartId";

        public void AddToCart(int id)
        {
            // Retrieve the product from the database.           
            ShoppingCartID = GetCartId();

            var cartItem = CartitemProxy.GetCartItemsWithSessionAndProductID(ShoppingCartID, id);
            if (cartItem.seassionID == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new CartItemData()
                {
                    
                    ProductID = id,
                    seassionID = ShoppingCartID,
                    Product = Productproxy.GetProductByID(id),
                    quantity = 1,
                    createdDate = DateTime.Now
                };

                CartitemProxy.InsertCartItem(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.quantity++;
                CartitemProxy.UpdateCartItem(cartItem);
            }
           
        }

        public void Dispose()
        {
            //if (CartitemProxy != null)
            //{
            //    CartitemProxy.Close();
            //    CartitemProxy = null;
            //}
            //if (Productproxy != null)
            //{
            //    Productproxy.Close();
            //    Productproxy = null;
            //}
        }

        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<CartItemData> GetCartItems()
        {
            ShoppingCartID = GetCartId();

            return CartitemProxy.GetCartItemDatas(ShoppingCartID);
            
        }

        public decimal GetTotal()
        {
            ShoppingCartID = GetCartId();
            decimal? total = decimal.Zero;
            var cartItems = GetCartItems();
            foreach (var item in cartItems)
            {
                total = total + (decimal.Parse(item.Product.price.ToString()) *decimal.Parse(item.quantity.ToString()));
            }
            return total ?? decimal.Zero;
        }

        public ShoppingcartActions GetCart(HttpContext context)
        {
            using (var cart = new ShoppingcartActions())
            {
                cart.ShoppingCartID = cart.GetCartId();
                return cart;
            }
        }

        public void UpdateShoppingCartDatabase(String cartId, ShoppingCartUpdates[] CartItemUpdates)
        {
            
                try
                {
                    int CartItemCount = CartItemUpdates.Count();
                    List<CartItemData> myCart = GetCartItems();
                    foreach (var cartItem in myCart)
                    {
                        // Iterate through all rows within shopping cart list
                        for (int i = 0; i < CartItemCount; i++)
                        {
                            if (cartItem.Product.productID == CartItemUpdates[i].ProductId)
                            {
                                if (CartItemUpdates[i].PurchaseQuantity < 1 || CartItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(cartId, int.Parse(cartItem.ProductID.ToString()));
                                }
                                else
                                {
                                    UpdateItem(cartId, int.Parse(cartItem.ProductID.ToString()), CartItemUpdates[i].PurchaseQuantity);
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Database - " + exp.Message.ToString(), exp);
                }
         
        }

        public void RemoveItem(string removeCartID, int removeProductID)
        {
            try
            {
                var removeItem = CartitemProxy.GetCartItemsWithSessionAndProductID(removeCartID, removeProductID);
                CartitemProxy.DeleteCartItem(removeItem);
            }
            catch (Exception exp)
            {
                    throw new Exception("ERROR: Unable to Remove Cart Item - " + exp.Message.ToString(), exp);
            }
         
        }

        public void UpdateItem(string updateCartID, int updateProductID, int quantity)
        {
            try
            {
                var updateItem = CartitemProxy.GetCartItemsWithSessionAndProductID(updateCartID, updateProductID);
                updateItem.quantity = quantity;
                CartitemProxy.UpdateCartItem(updateItem);
            }
            catch (Exception exp)
            {
                throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
            }


        }

        public void EmptyCart()
        {
            ShoppingCartID = GetCartId();
            var cartItems = CartitemProxy.GetCartItemDatas(ShoppingCartID);
            foreach (var cartItem in cartItems)
            {
                cartItem.seassionID = ShoppingCartID;
                CartitemProxy.DeleteCartItem(cartItem);
            }
        }

        public int GetCount()
        {
            

            ShoppingCartID = GetCartId();

            // Get the count of each item in the cart and sum them up          
            int? count = 0;
            var cartItems = GetCartItems();
            foreach (var item in cartItems)
            {
                count = count + item.quantity;
            }
            // Return 0 if all entries are null         
            return count ?? 0;
        }

        public struct ShoppingCartUpdates
        {
            public int ProductId;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }
    }
}