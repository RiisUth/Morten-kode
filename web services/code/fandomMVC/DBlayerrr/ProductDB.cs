
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptions;

namespace DBlayerrr
{
    public class ProductDB : IProductDB
    {
        private int tries = 0;
        fandomDBDataContext db = new fandomDBDataContext();
        public void insertProduct(Product Product)
        {
            db.Products.InsertOnSubmit(Product);
            db.SubmitChanges();
        }

        public Product getProductByID(int id)
        {
            var products = db.Products;
            Product firstproduct = (from a in products
                                    where a.productID == id
                                    select a).SingleOrDefault();
            return firstproduct;

        }

        public IEnumerable<Product> GetProducts()
        {
            var products = db.Products;
            var productss = (from p in products select p).AsEnumerable();
            return productss;

        }

        public void removeProduct(Product product)
        {
            db.Products.DeleteOnSubmit(product);
            db.SubmitChanges();
        }

        //need human test
        public void UpdateProduct(Product product)
        {
            Product product1 = db.Products.SingleOrDefault(p => p.productID == product.productID);

            product1.price = product.price;
            product1.productName = product.productName;
            product1.productDescription = product.productDescription;
            product1.quantity = product.quantity;

            db.SubmitChanges();

        }
        public void MinusProductQuantity(int productID, int quntity)
        {
            Product product1 = db.Products.SingleOrDefault(p => p.productID == productID);
            product1.quantity = product1.quantity - quntity;
                if (product1.quantity < 0)
                {
                    string nomoreP = "there is no more Products";
                    throw new NoMoreProductsException(nomoreP);

                }
                else
                {
                db.SubmitChanges();
                }
        }

        public void PlusProductQuantity(int productID, int quntity)
        {
            
            Product product1 = db.Products.SingleOrDefault(p => p.productID == productID);
            product1.quantity = +quntity;
            db.SubmitChanges();

            
            
        }

        public Product GetProductByName(string name)
        {
            var products = db.Products;
            Product firstproduct = (from a in products
                                    where a.productName == name
                                    select a).SingleOrDefault();
            return firstproduct;
        }

        public void productToInvisible(Product product)
        {
            Product product1 = db.Products.SingleOrDefault(p => p.productID == product.productID);

            product1.visible = false;
            db.SubmitChanges();
        }

        public void productToVisible(Product product)
        {
            Product product1 = db.Products.SingleOrDefault(p => p.productID == product.productID);

            product1.visible = true;
            db.SubmitChanges();
        }

        public IEnumerable<Product> GetlikeProdctNames(string name)
        {
            var products = db.Products;
            var productss = (from p in products where p.productName.IndexOf(name) >= 0 select p).AsEnumerable();
            return productss;
        }
    }
    
}