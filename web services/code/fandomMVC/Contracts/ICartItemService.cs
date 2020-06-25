using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;


namespace Contracts
{
    [ServiceContract]
    public interface ICartItemService
    {
        [OperationContract]
        void InsertCartItem(CartItemData cartItemData);
        [OperationContract]
        CartItemData GetCartItemsWithSessionAndProductID(string sessionID, int productID);
        [OperationContract]
        List<CartItemData> GetCartItemDatas(string session);
        [OperationContract]
        void UpdateCartItem(CartItemData cartItemData);
        [OperationContract]
        void DeleteCartItem(CartItemData cartItemData);
    }
}