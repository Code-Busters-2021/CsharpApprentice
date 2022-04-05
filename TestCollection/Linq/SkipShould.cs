using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;
using System.Linq;


namespace TestCollection.Linq
{
    [TestFixture]
    public class SkipShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "number")]
        public void TestSingleString()
        {
            IEnumerable<int> numbers = new int[] {1, 2, 3, 4, 5};
            IEnumerable<int> expectedResult = new int[] {3, 4, 5};

            IEnumerable<int> numbersAfterSkip = numbers.Skip(2);
            CollectionAssert.AreEqual(numbersAfterSkip, expectedResult, $"Skip doesn't work");
        }

        // TODO Implement Empty

    }
}
