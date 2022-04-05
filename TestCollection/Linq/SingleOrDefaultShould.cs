using NUnit.Framework;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;


namespace TestCollection.Linq
{
    [TestFixture]
    public class SingleOrDefaultShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "number")]
        public void TestSigleOrDefaultNumberNotEmpty()
        {
            IEnumerable<int> numbers = new int[] {1};
            int expectedResult = 1;

            int numberAfterSigleOrDefault = numbers.SingleOrDefault();
            Assert.AreEqual(numberAfterSigleOrDefault, expectedResult);
        }

        [Test(Description = "string")]
        public void TestSigleOrDefaultnumberEmpty()
        {
            IEnumerable<int> numbers = new int[] {};
            int expectedResult = 0;

            int numberAfterSigleOrDefault = numbers.SingleOrDefault();
            Assert.AreEqual(numberAfterSigleOrDefault, expectedResult);
        }

        /*[Test(Description = "string")]
        public void TestSingleOrDefaultThrow()
        {
            IEnumerable<int> numbers = new int[] {};

            int numberAfterSigleOrDefault = numbers.SingleOrDefault();
            Assert.Throws<TargetInvocationException>(numbers.SingleOrDefault());
        }*/

    }
}
