using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;
using System.Linq;

namespace TestCollection 
{
    public class TakeWhileShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "Test Take")]
        public void ShouldStringWhithIndex()
        {
            List<string> strings = new List<string>() {"one", "two", "tree", "four", "five"};
            List<string> expectedResult = new List<string>() {"one", "two", "tree"};

            var stringsAfterTake = strings.TakeWhile((str, index) => str.Length >= index);
            CollectionAssert.AreEqual(stringsAfterTake, expectedResult);
        }

        [Test(Description = "Test Take")]
        public void ShouldIntegerWithIndex()
        {
            List<int> integers = new List<int>() {1, 2, 3, 4, 5};
            List<int> expectedResult = new List<int>() {1, 2};

            var integersAfterTake = integers.TakeWhile((integer, index) => integer != index);
            CollectionAssert.AreEqual(integersAfterTake, expectedResult);
        }

        [Test(Description = "Test Take")]
        public void ShouldInteger()
        {
            List<int> integers = new List<int>() {1, 2, 3, 4, 5};
            List<int> expectedResult = new List<int>() {1, 2};

            var integersAfterTake = integers.TakeWhile(integer => integer < 3);
            CollectionAssert.AreEqual(integersAfterTake, expectedResult);
        }
    }
}