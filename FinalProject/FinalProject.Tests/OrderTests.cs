using NUnit.Framework;
using FinalProject.Lib;
using System.Collections.Generic;

namespace FinalProject.Tests
{
    public class OrderTests
    {
        private Order _order;
        private Product _tshirt;

        [SetUp]
        public void SetUp()
        {
            _tshirt = new Product("T-Shirt", 30m, new List<Size>
            {
                new Size("XS", "Extra Small"),
                new Size("S", "Small"),
                new Size("M", "Medium"),
                new Size("L", "Large"),
                new Size("XL", "Extra Large")
            });

            var cart = new ShoppingCart();
            cart.AddProduct(_tshirt);
            cart.CalculateTotalCost(5m, 10m); 

            _order = new Order(new List<Product> { _tshirt }, cart.TotalCost);
        }

        [Test]
        public void TestOrderInitialization()
        {
            Assert.AreEqual(1, _order.Products.Count);
            Assert.AreEqual(45m, _order.TotalCost);
        }

        [Test]
        public void TestOrderCompletion()
        {
            _order.CompleteOrder();
            Assert.IsTrue(_order.IsCompleted);
        }
    }
}
