using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;
using System.Linq;


namespace TestCollection.Linq
{
    [TestFixture]
    public class FirstOrDefaultShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "number")]
        public void TestFirstOrDefaultNumber()
        {
            List<int> numbers = new List<int>() { 1 };
            int expectedResult = 1;
        
            int first = numbers.FirstOrDefault();    
            Assert.AreEqual(first, expectedResult);
        }

        [Test(Description = "string")]
        public void TestFirstOrDefaulttEmpty()
        {
            List<int> numbers = new List<int>() { };
            int expectedResult = 0;
        
            int first = numbers.FirstOrDefault();    
            Assert.AreEqual(first, expectedResult);
        }        

        [Test(Description = "number")]
        public void TestFirstOrDefaultMultipleNumber()
        {
            List<int> numbers = new List<int>() { 1, 2, 3 };
            int expectedResult = 1;
        
            int first = numbers.FirstOrDefault();    
            Assert.AreEqual(first, expectedResult);
        }
    }
}
