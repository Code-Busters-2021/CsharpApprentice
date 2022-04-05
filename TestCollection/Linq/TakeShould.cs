using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;
using System.Linq;

namespace TestCollection 
{
    public class TakeShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "Test Take")]
        public void ShouldString()
        {
            List<string> strings = new List<string>() {"one", "two", "tree", "four", "five"};
            List<string> expectedResult = new List<string>() {"one", "two", "tree"};

            var stringsAfterTake = strings.Take(3);
            CollectionAssert.AreEqual(stringsAfterTake, expectedResult);
        }

        [Test(Description = "Test Take")]
        public void ShouldInteger()
        {
            List<int> integers = new List<int>() {1, 2, 3, 4, 5};
            List<int> expectedResult = new List<int>() {1, 2, 3};

            var integersAfterTake = integers.Take(3);
            CollectionAssert.AreEqual(integersAfterTake, expectedResult);
        }
    }
}