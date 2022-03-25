using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;
using System.Linq;


namespace TestCollection.Linq
{
    [TestFixture]
    public class WhereShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "Where")]
        public void TestNegativValue()
        {
            IEnumerable<int> numbers = new int[] {1, 3, -1, -4, 3, -5};
            IEnumerable<int> expectedResult = new int[] {1, 3, 3};

            var numbersAfterWhere = numbers.Where(i => i < 0);
            CollectionAssert.AreEqual(numbersAfterWhere, expectedResult, $"where doesn't work");
        }

        [Test(Description = "Where")]
        public void TestString()
        {
            IEnumerable<string> numbers = new string[] {"Paul", "Pierre", "jaque", "Paulette", "LeoPaul"};
            IEnumerable<string> expectedResult = new string[] {"Paul", "Paulette", "LeoPaul"};

            var numbersAfterWhere = numbers.Where(s => s.Contains("Paul"));
            CollectionAssert.AreEqual(numbersAfterWhere, expectedResult, $"where doesn't work");
        }

        [Test(Description = "Where")]
        public void TestEmpty()
        {
            IEnumerable<int> numbers = new int[] {};
            IEnumerable<int> expectedResult = new int[] {};

            IEnumerable<int> numbersAfterWhere = numbers.Where(i => i < 0);
            // CollectionAssert.IsEmpty(numbersAfterWhere, expectedResult);
        }

    }
}
