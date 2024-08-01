using NUnit.Framework;
using FinalProject.Lib;
using System.Collections.Generic;

namespace FinalProject.Tests
{
    public class ProductTests
    {
        private Product _tshirt;
        private Product _hoodie;
        private Product _jeans;

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

            _hoodie = new Product("Hoodie", 50m, new List<Size>
            {
                new Size("XS", "Extra Small"),
                new Size("S", "Small"),
                new Size("M", "Medium"),
                new Size("L", "Large"),
                new Size("XL", "Extra Large")
            });

            _jeans = new Product("Jeans", 80m, new List<Size>
            {
                new Size("30", "Size 30"),
                new Size("32", "Size 32"),
                new Size("34", "Size 34"),
                new Size("36", "Size 36"),
                new Size("38", "Size 38")
            });
        }

        [Test]
        public void TestProductInitialization()
        {
            Assert.AreEqual("T-Shirt", _tshirt.Name);
            Assert.AreEqual(30m, _tshirt.Price);
            Assert.AreEqual(5, _tshirt.Sizes.Count);
        }

        [Test]
        public void TestProductSizeSelection()
        {
            var size = _tshirt.Sizes.Find(s => s.Name == "M");
            Assert.NotNull(size);
            Assert.AreEqual("Medium", size.Description);
        }
    }
}
