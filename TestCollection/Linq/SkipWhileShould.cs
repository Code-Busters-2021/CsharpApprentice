using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;
using System.Linq;


namespace TestCollection.Linq
{
    [TestFixture]
    public class SkipWhileShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "number")]
        public void TestWhithIndex()
        {
            IEnumerable<int> numbers = new int[] {1, 2, 2, 4, 5};
            IEnumerable<int> expectedResult = new int[] {2, 4, 5};

            IEnumerable<int> numbersAfterSkipWhile = numbers.SkipWhile((value, index) => value != index);
            CollectionAssert.AreEqual(numbersAfterSkipWhile, expectedResult, $"Skip doesn't work");
        }

        [Test(Description = "number")]
        public void TestWhile()
        {
            IEnumerable<int> numbers = new int[] {1, 2, 3, 4, 5};
            IEnumerable<int> expectedResult = new int[] {3, 4, 5};

            IEnumerable<int> numbersAfterSkipWhile = numbers.SkipWhile(value => value % 3 != 0);
            CollectionAssert.AreEqual(numbersAfterSkipWhile, expectedResult, $"Skip doesn't work");
        }

        // TODO Implement Empty

    }
}
