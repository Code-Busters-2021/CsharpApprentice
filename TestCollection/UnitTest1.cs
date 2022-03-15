using NUnit.Framework;

namespace TestCollection
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test]
        public void TestEmpty()
        {
            Assert.That(MyList.RemoveAll().Length, Is.EqualTo(0));
        }

        [Test]
        public void TestRemoveFromNonEmpty()
        {
            
        }

        public void CeciNestPasUnTest()
        {

        }
    }
}
