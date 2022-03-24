using NUnit.Framework;
using CollectionRewrite;

namespace TestCollection
{
    [TestFixture]
    public class ListShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "TestAdd")]
        public void TestAdd()
        {
            // Assert.That(MyList.RemoveAll().Length, Is.EqualTo(0));
        }

        [Test]
        public void TestRemoveFromNonEmpty()
        {
           MyList<int> test = new MyList<int>(new int[] {2, 3});
        }

        public void CeciNestPasUnTest()
        {

        }
    }
}
