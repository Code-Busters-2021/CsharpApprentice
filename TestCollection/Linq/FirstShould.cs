using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;
using System.Linq;


namespace TestCollection.Linq
{
    [TestFixture]
    public class FirstShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "number")]
        public void TestFirstNumber()
        {
            IEnumerable<int> numbers = new int[] {9, 5, 4, -4, 455, 3, -9, 0};
            int expectedResult = -4;

            int numbersAfterWhere = numbers.First(n => n < 0);
            Assert.AreEqual(numbersAfterWhere, expectedResult, $"where doesn't work");
        }

        [Test(Description = "string")]
        public void TestfirstString()
        {
            IEnumerable<string> numbers = new string[] {"z", "taa", "uz", "ye", "qr"};
            string expectedResult = "taa";

            var numbersAfterWhere = numbers.First(s => s.Contains("aa"));
            CollectionAssert.AreEqual(numbersAfterWhere, expectedResult, $"where doesn't work");
        }        


    }
}
