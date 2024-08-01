using NUnit.Framework;
using FinalProject.Lib;

namespace FinalProject.Tests
{
    public class SizeTests
    {
        private Size _size;

        [SetUp]
        public void SetUp()
        {
            _size = new Size("M", "Medium");
        }

        [Test]
        public void TestSizeInitialization()
        {
            Assert.AreEqual("M", _size.Name);
            Assert.AreEqual("Medium", _size.Description);
        }
    }
}
