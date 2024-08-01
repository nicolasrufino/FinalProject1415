using NUnit.Framework;
using FinalProject.Lib;
using System.Collections.Generic;

namespace FinalProject.Tests
{
    public class ShoppingCartTests
    {
        private ShoppingCart _cart;
        private Product _tshirt;
        private Product _hoodie;

        [SetUp]
        public void SetUp()
        {
            _cart = new ShoppingCart();

            _tshirt = new Product("T-Shirt", 30m, new List<Size>
            {
                new Size("XS", "Extra Small"),
                new Size("S", "Small"),
                new Size("M", "Medium"),
                new Size("L", "Large"),
                new Size("XL", "Extra Large")
            });

            _hoodie = new Product("Hoodie", 50m, new List<Size>
            {
                new Size("XS", "Extra Small"),
                new Size("S", "Small"),
                new Size("M", "Medium"),
                new Size("L", "Large"),
                new Size("XL", "Extra Large")
            });
        }

        [Test]
        public void TestAddProductToCart()
        {
            _cart.AddProduct(_tshirt);
            Assert.AreEqual(1, _cart.CartItems.Count);
        }

        [Test]
        public void TestCalculateTotalCost()
        {
            _cart.AddProduct(_tshirt);
            _cart.CalculateTotalCost(5m, 10m);
            Assert.AreEqual(45m, _cart.TotalCost);
        }

        [Test]
        public void TestClearCart()
        {
            _cart.AddProduct(_tshirt);
            _cart.ClearCart();
            Assert.AreEqual(0, _cart.CartItems.Count);
        }
    }
}
