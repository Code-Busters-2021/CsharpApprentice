using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;
using System.Linq;

namespace TestCollection
{
    [TestFixture]
    public class InvertShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "TestInvert")]
        public void TestAdd()
        {
            // Assert.That(MyList.RemoveAll().Length, Is.EqualTo(0));
        }

        [Test]
        public void TestRemoveFromNonEmpty()
        {
            IEnumerable<int> enumerableNumbers = new int[] {1, 2, 3, 4, 5, 6};
            InvertedEnumerable invertedEnumerable = new InvertedEnumerable(enumerableNumbers);

            IEnumerable<double> resultEnumerable = enumerableNumbers.Select(x => 1 / x);


        }

        public void CeciNestPasUnTest()
        {

        }
    }
}