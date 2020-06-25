using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBlayerrr
{
    public class CartItemDB : ICartItemDB
    {
        fandomDBDataContext db = new fandomDBDataContext();

        public void DeleteCartItem(CartItem cartItem)
        {
            var deleteItem = GetCartItemsWithSessionAndProductID(cartItem.sessionID, cartItem.Product.productID);
            db.CartItems.DeleteOnSubmit(deleteItem);
            db.SubmitChanges();
        }

        public IEnumerable<CartItem> getCartItems(string sessionID)
        {
            var cartItems = (from a in db.CartItems where a.sessionID == sessionID select a).AsEnumerable();

            return cartItems;
        }

        public CartItem GetCartItemsWithSessionAndProductID(string sessionID, int productID)
        {
            var cartItem = (from b in db.CartItems where b.sessionID == sessionID && b.productID == productID select b).SingleOrDefault();
            return cartItem;
        }

        public void InsertCartItem(CartItem cartItem)
        {
            db.CartItems.InsertOnSubmit(cartItem);
            db.SubmitChanges();
        }

        public void UpdatecartItem(CartItem cartItem)
        {
            var cartItem1 = db.CartItems.SingleOrDefault(C => C.cartItemID == cartItem.cartItemID);

            cartItem1.cartItemID = cartItem.cartItemID;
            cartItem1.createdDate = cartItem.createdDate;
            cartItem1.quantity = cartItem.quantity;
            cartItem1.sessionID = cartItem.sessionID;
            db.SubmitChanges();
        }
    }
}
