using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;
using System.Linq;


namespace TestCollection.Linq
{
    [TestFixture]
    public class OrderByDescendingShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "number")]
        public void TestOrderByDescendingNumber()
        {
            IEnumerable<int> numbers = new int[] {9, 5, 4, -4, 455, 3, -9, 0};
            IEnumerable<int> expectedResult = new int[] {455, 9, 5, 4, 3, 0, -4, -9};

            IEnumerable<int> numbersAfterWhere = numbers.OrderByDescending(n => n);
            CollectionAssert.AreEqual(numbersAfterWhere, expectedResult, $"where doesn't work");
        }

        [Test(Description = "string")]
        public void TestOrderByDescendingString()
        {
            IEnumerable<string> numbers = new string[] {"z", "taa", "uz", "ye", "qr"};
            IEnumerable<string> expectedResult = new string[] {"z", "ye", "uz", "taa", "qr"};

            IEnumerable<string> numbersAfterWhere = numbers.OrderByDescending(n => n);
            CollectionAssert.AreEqual(numbersAfterWhere, expectedResult, $"where doesn't work");
        }        


    }
}
