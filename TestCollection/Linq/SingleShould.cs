using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;
using System.Linq;


namespace TestCollection.Linq
{
    [TestFixture]
    public class SingleShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "number")]
        public void TestSingleString()
        {
            IEnumerable<string> numbers = new string[] {"un"};
            string expectedResult = "un";

            string numbersAfterWhere = numbers.Single();
            CollectionAssert.AreEqual(numbersAfterWhere, expectedResult, $"where doesn't work");
        }

        [Test(Description = "string")]
        public void TestSingleFail()
        {
            IEnumerable<string> numbers = new string[] {"un", "deux"};
            string expectedResult = "un";

            // string numbersAfterWhere = numbers.Single();
            // CollectionAssert.AreEqual(numbersAfterWhere, expectedResult, $"where doesn't work");
        }        


    }
}
