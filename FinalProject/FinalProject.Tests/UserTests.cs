using NUnit.Framework;
using FinalProject.Lib;

namespace FinalProject.Tests
{
    public class UserTests
    {
        private User _user;

        [SetUp]
        public void SetUp()
        {
            _user = new User("testuser", "password123");
        }

        [Test]
        public void TestUserInitialization()
        {
            Assert.AreEqual("testuser", _user.Username);
        }

        [Test]
        public void TestUserLogin()
        {
            Assert.IsTrue(_user.Login("password123"));
        }

        [Test]
        public void TestUserInvalidLogin()
        {
            Assert.IsFalse(_user.Login("wrongpassword"));
        }
    }
}
