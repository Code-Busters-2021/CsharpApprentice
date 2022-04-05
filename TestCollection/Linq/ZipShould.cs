using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;


namespace TestCollection.Linq
{
    [TestFixture]
    public class ZipShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "Where")]
        public void TestStringAndIntValue()
        {
            IEnumerable<int> numbers = new int[] {1, 2, 3, 4, 5};
            IEnumerable<string> strings = new string[] {"one", "two", "tree", "four"};
            IEnumerable<string> expectedResult = new string[] {"1: one", "2: two", "3: tree", "4: four"};

            IEnumerable<string> stringsAfterZip = numbers.Zip(strings, (first, segond) => first + ": " + segond);
            CollectionAssert.AreEqual(stringsAfterZip, expectedResult, $"where doesn't work");
        }

         [Test(Description = "Where")]
        public void TestNumbrsValue()
        {
            IEnumerable<int> firstNumbers = new int[] {1, 2, 3, 4, 5};
            IEnumerable<int> segondNumbers = new int[] {11, 22, 33, 44};
            IEnumerable<int> expectedResult = new int[] {22, 34, 46, 58};

            IEnumerable<int> numbersAfterZip = firstNumbers.Zip(segondNumbers, (first, segond) => first + 10 + segond);
            CollectionAssert.AreEqual(numbersAfterZip, expectedResult, $"where doesn't work");
        }

    }
}
