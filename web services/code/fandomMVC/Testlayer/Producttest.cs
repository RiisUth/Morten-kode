using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBlayerrr;

namespace BankTests
{
    [TestClass]
    public class Producttest
    {
        [TestMethod]
        public void testProductclass()
        {
            // Arrange
            string expected = "Monster";
            var a = new Product();
            a.productName = "Monster";


            // Act


            // Assert
            string actual = a.productName;
            Assert.AreEqual(expected, actual);
       
        }
    }
}
