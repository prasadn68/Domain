using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class MyTestFixture
    {
        [Test]
        public void MyFirstTest()
        {
            var result = 2 + 2;

            Assert.AreEqual(4, result);
        }
    }
}