using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;

namespace TestCollection
{
    [TestFixture]
    public class ListShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "Length")]
        public void TestLength()
        {
            List<int> referanceNumbers = new List<int>() {2, 3};
            MyList<int> listTest = new MyList<int>(new int[] {2, 3});

            Assert.AreEqual(listTest.Length, referanceNumbers.Count);
        }

        [Test(Description = "Add")]
        public void TestAdd()
        {
            List<int> referanceNumbers = new List<int>();
            MyList<int> ListTest = new MyList<int>();

            referanceNumbers.Add(2);
            ListTest.Add(2);
            Assert.AreEqual(referanceNumbers[0], ListTest[0]);
            // Assert.That(MyList.RemoveAll().Length, Is.EqualTo(0));
        }

        [Test(Description = "Insert")]
        public void TestInsert()
        {
            List<int> referanceNumbers = new List<int>() {1, 3, 4};
            MyList<int> ListTest = new MyList<int>(new int[] {1, 3, 4});

            referanceNumbers.Insert(2, 5);
            ListTest.Insert(2, 5);
            for (int i = 0; i < referanceNumbers.Count; i++) {
                Assert.AreEqual(ListTest[i], referanceNumbers[i]);
            }
        }

        [Test(Description = "RemoveFromNonEmpty")]
        public void TestRemoveFromNonEmpty()
        {
            List<int> referanceNumbers = new List<int>() {2, 3};
            MyList<int> listTest = new MyList<int>(new int[] {2, 3});

            listTest.Remove(3);
            referanceNumbers.Remove(3);
            for (int i = 0; i < referanceNumbers.Count; i++) {
                Assert.AreEqual(listTest[i], referanceNumbers[i]);
            }
        }

        [Test(Description = "RemoveFromNonEmpty")]
        public void TestRemoveAtFromNonEmpty()
        {
            List<int> referanceNumbers = new List<int>() {1, 2, 3};
            MyList<int> listTest = new MyList<int>(new int[] {1, 2, 3});

            listTest.Remove(2);
            referanceNumbers.Remove(2);
            for (int i = 0; i < referanceNumbers.Count; i++) {
                Assert.AreEqual(listTest[i], referanceNumbers[i]);
            }
        }
    }
}
