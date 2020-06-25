using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Contracts; 

namespace Proxies
{
    public class CartItemClient : ClientBase<ICartItemService>, ICartItemService
    {
        public void DeleteCartItem(CartItemData cartItemData)
        {
            Channel.DeleteCartItem(cartItemData);
        }

        public List<CartItemData> GetCartItemDatas(string session)
        {
            return Channel.GetCartItemDatas(session);
        }

        public CartItemData GetCartItemsWithSessionAndProductID(string sessionID, int productID)
        {
            return Channel.GetCartItemsWithSessionAndProductID(sessionID, productID);
        }

        public void InsertCartItem(CartItemData cartItemData)
        {
            Channel.InsertCartItem(cartItemData); 
        }

        public void UpdateCartItem(CartItemData cartItemData)
        {
            Channel.UpdateCartItem(cartItemData);
        }
    }
}
