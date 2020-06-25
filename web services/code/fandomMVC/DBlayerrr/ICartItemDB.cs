using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBlayerrr
{
     public interface ICartItemDB
    {
        void InsertCartItem(CartItem cartItem);
        CartItem GetCartItemsWithSessionAndProductID(string sessionID, int productID);
        IEnumerable<CartItem> getCartItems(string sessionID);

        void UpdatecartItem(CartItem cartItem);

        void DeleteCartItem(CartItem cartItem);
    }
}
