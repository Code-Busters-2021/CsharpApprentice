using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;

namespace TestCollection
{
    [TestFixture]
    public class LinkedListShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "Length")]
        public void TestLength()
        {
            LinkedList<int> referanceNumbers = new LinkedList<int>(new int[] {1, 2, 3, 4, 5});
            MyLikedList<int> listTest = new MyLikedList<int>(new int[] {1, 2, 3, 4, 5});

            Assert.AreEqual(listTest.Count, referanceNumbers.Count);
            MyLikedList<int> _listTest = listTest;

            /*foreach (var elem in referanceNumbers) {
                Assert.AreEqual(elem, )
            }*/
        }


        [Test(Description = "Add first")]
        public void TestAddFirst()
        {
            LinkedList<int> referanceNumbers = new LinkedList<int>();
            MyLikedList<int> listTest = new MyLikedList<int>();

            referanceNumbers.AddFirst(4);
            listTest.AddFirst(4);

            Assert.AreEqual(listTest.Count, referanceNumbers.Count);

        }
    }
}
