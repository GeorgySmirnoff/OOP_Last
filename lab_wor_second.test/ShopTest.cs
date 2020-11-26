using lab_work_second;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace lab_wor_second.test
{
    [TestClass]
    public class ShopTest
    {
        private Product product1;
        private Product product2;

        [TestInitialize]
        public void TestInitialize()
        {
            product1 = new Product("tomato");
            product2 = new Product("apple");
        }

        [TestMethod]
        public void ConstructorShop()
        {
            string name = "Abvgd";
            string address = "Chkalovskay";
            int expectedID = 1;

            Shop shop = new Shop(name, address);

            Assert.AreEqual(name, shop.Name);
            Assert.AreEqual(address, shop.Address);
            Assert.AreEqual(expectedID, shop.ID);
        }

        [TestMethod]
        public void FindProduct()
        {
            var noProduct = new Product("noProduct");
            var product = new Product("Tomato");
            var shop = new Shop("First", "Pervii");

            shop.AddProduct(product, 3, 100);
            shop.AddProduct(product, 1, 50);

            //6
            var tupleList = new List<Tuple<Product, int>> { Tuple.Create(product, 3) };


            var p = shop.FindProduct(product);
            var pCheap = shop.FindCheapProduct(product);

            var res = shop.ResultOfBuy(tupleList);

            //var res = shop.ResultOfBuy(tupleList);
            //Assert.AreEqual(p.Cost, 100);
            //Assert.AreEqual(pCheap.Cost, 50);

            Assert.AreEqual(res, 300);
        }

    }
}
