using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;
using System.Linq;


namespace TestCollection.Linq
{
    [TestFixture]
    public class OrderByShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "number")]
        public void TestOrderByNumber()
        {
            IEnumerable<int> numbers = new int[] {9, 5, 4, -4, 455, 3, -9, 0};
            IEnumerable<int> expectedResult = new int[] {-9, -4, 0, 3, 4, 5, 9, 455};

            var numbersAfterWhere = numbers.OrderBy(n => n);
            CollectionAssert.AreEqual(numbersAfterWhere, expectedResult, $"where doesn't work");
        }

        [Test(Description = "string")]
        public void TestOrderByString()
        {
            IEnumerable<string> numbers = new string[] {"z", "taa", "uz", "ye", "qr"};
            IEnumerable<string> expectedResult = new string[] {"z", "taa", "uz", "ye", "qr"};

            var numbersAfterWhere = numbers.OrderBy(n => n);
            CollectionAssert.AreEqual(numbersAfterWhere, expectedResult, $"where doesn't work");
        }        


    }
}
