using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Exceptions;

namespace Contracts
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        ProductData GetProductByID(int ID);
        [OperationContract]
        void Insertproduct(ProductData productData);
        [OperationContract]
        void RemoveProduct(ProductData productData);
        [OperationContract]
        void updateProduct(ProductData productData);
        [OperationContract]
        List<ProductData> GetProducts();
        [OperationContract]
        ProductData GetProductByName(string Name);
        [OperationContract]
        void setVisibleTofalse(ProductData productData);
        [OperationContract]
        void setVisibleTotrue(ProductData productData);
        [OperationContract]
        IEnumerable<ProductData> GetlikeProdctNames(string name);
        [OperationContract]
        void MinusProductQuantity(int productID, int quntity);
        [OperationContract]
        void PlusProductQuantity(int productID, int quntity);

    }
}