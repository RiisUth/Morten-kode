using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DBlayerrr;

namespace Services
{
    public class CartItemService : ICartItemService
    {
        ICartItemDB _cartItemDB = null;

        public CartItemService ()
        {
        }
        public CartItemService (ICartItemDB cartItemDB)
        {
            this._cartItemDB = cartItemDB;
        }

        public void DeleteCartItem(CartItemData cartItemData)
        {
            IProductDB productDB = new ProductDB();
            ICartItemDB cartItemDB = _cartItemDB ?? new CartItemDB();
            CartItem cartItem = new CartItem();
            var check = cartItemDB.GetCartItemsWithSessionAndProductID(cartItemData.seassionID, cartItemData.Product.productID);
            if (check != null && cartItemData != null)
            {
                cartItem.cartItemID = cartItemData.cartItemID;
                cartItem.createdDate = cartItemData.createdDate;
                cartItem.quantity = cartItemData.quantity;
                cartItem.sessionID = cartItemData.seassionID;
                cartItem.productID = cartItemData.ProductID;
                cartItem.Product = productDB.getProductByID(int.Parse(check.productID.ToString())); ;
            }
            cartItemDB.DeleteCartItem(cartItem);
        }

        public List<CartItemData> GetCartItemDatas(string session)
        {
            ICartItemDB cartItemDB = _cartItemDB ?? new CartItemDB();
            List<CartItemData> cartItemDatas = new List<CartItemData>(); 
            IEnumerable<CartItem> check = cartItemDB.getCartItems(session);
            if (check != null)
            {
                ProductServices productServices = new ProductServices();
                foreach (var item in check)
                {
                    CartItemData cartItemData = new CartItemData();
                    cartItemData.cartItemID = item.cartItemID;
                    cartItemData.createdDate = item.createdDate;
                    cartItemData.Product = new ProductData();
                    cartItemData.Product.productID = item.Product.productID;
                    cartItemData.Product.productName = item.Product.productName;
                    cartItemData.Product.quantity = item.Product.quantity;
                    cartItemData.Product.productDescription = item.Product.productDescription;
                    cartItemData.Product.supplierID = item.Product.supplierID;
                    cartItemData.Product.price = item.Product.price;
                    cartItemData.Product.imageDatas = new List<ImageData>();
                    foreach (var itemet in item.Product.Images)
                    {
                        ImageData imageData = new ImageData();
                        imageData.imgID = itemet.imageID;
                        imageData.imagePath = itemet.imagePath;
                        imageData.productID = itemet.productID;
                        cartItemData.Product.imageDatas.Add(imageData);
                    }
                    cartItemData.quantity = int.Parse(item.quantity.ToString()); ;
                    cartItemData.Product.mainImgSrc = cartItemData.Product.imageDatas[0].imagePath;
                    cartItemData.Product.viasble = item.Product.visible;
                    cartItemData.ProductID = cartItemData.Product.productID;
                    cartItemDatas.Add(cartItemData);
                }
            }
            return cartItemDatas;
        }

        public CartItemData GetCartItemsWithSessionAndProductID(string sessionID, int productID)
        {
            ICartItemDB cartItemDB = _cartItemDB ?? new CartItemDB();
            CartItemData cartItemData = new CartItemData();
            var check = cartItemDB.GetCartItemsWithSessionAndProductID(sessionID, productID);
            if (check != null)
            {
                ProductServices productServices = new ProductServices();
                cartItemData.cartItemID = check.cartItemID;
                cartItemData.createdDate = check.createdDate;
                cartItemData.Product = productServices.GetProductByID(productID);
                cartItemData.quantity = int.Parse(check.quantity.ToString());
                cartItemData.seassionID = check.sessionID;
                cartItemData.ProductID = cartItemData.Product.productID;
            }
            return cartItemData;
        }

        public void InsertCartItem(CartItemData cartItemData)
        {
            ICartItemDB cartItemDB = _cartItemDB ?? new CartItemDB();
            CartItem cartItem = new CartItem();
            var check = cartItemDB.GetCartItemsWithSessionAndProductID(cartItemData.seassionID, cartItemData.Product.productID);
            if (check ==null && cartItemData !=null)
            {
                cartItem.createdDate =  cartItemData.createdDate;
                cartItem.quantity = cartItemData.quantity;
                cartItem.sessionID = cartItemData.seassionID;
  
                cartItem.productID = cartItemData.ProductID;

            }
            cartItemDB.InsertCartItem(cartItem);
        }

        public void UpdateCartItem(CartItemData cartItemData)
        {
            ICartItemDB cartItemDB = _cartItemDB ?? new CartItemDB();
            CartItem cartItem = new CartItem();
            var check = cartItemDB.GetCartItemsWithSessionAndProductID(cartItemData.seassionID, cartItemData.Product.productID);
            if (check != null && cartItemData != null)
            {
                cartItem.cartItemID = check.cartItemID;
                cartItem.createdDate = cartItemData.createdDate;
                cartItem.quantity = cartItemData.quantity;
                cartItem.sessionID = cartItemData.seassionID;
                

            }
            cartItemDB.UpdatecartItem(cartItem);
        }
    }
}
