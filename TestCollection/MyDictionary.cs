using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;

namespace TestCollection
{
    [TestFixture]
    public class MyDictionaryShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "Length")]
        public void TestLength()
        {
            Dictionary<string, int> referanceDictionary = new Dictionary<string, int>();
            referanceDictionary.Add("Un", 1);
            referanceDictionary.Add("Deux", 2);
            MyDictionary<string, int> shouldNumbers = new MyDictionary<string, int>();
            shouldNumbers.Add("Un", 1);
            shouldNumbers.Add("Deux", 2);

            Assert.AreEqual(referanceDictionary.Count, shouldNumbers.Count);
        }

        [Test(Description = "Add")]
        public void TestAdd()
        {
            Dictionary<string, int> referanceDictionary = new Dictionary<string, int>();
            MyDictionary<string, int> shouldNumbers = new MyDictionary<string, int>();

            referanceDictionary.Add("un", 1);
            shouldNumbers.Add("un", 1);
            Assert.AreEqual(referanceDictionary["un"], shouldNumbers["un"]);
            // Assert.That(MyList.RemoveAll().Length, Is.EqualTo(0));
        }

        [Test(Description = "Insert")]
        public void TestInsert()
        {
            Dictionary<string, int> referanceDictionary = new Dictionary<string, int>();
            MyDictionary<string, int> shouldNumbers = new MyDictionary<string, int>();

            referanceDictionary.Add("un", 1);
            shouldNumbers.Add("un", 1);
            // Assert.Throws(() => shouldNumbers.TryInsert("un", 2));
            Assert.AreEqual(referanceDictionary["un"], shouldNumbers["un"]);
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
