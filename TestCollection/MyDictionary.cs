using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;
using System;

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
        public void ShouldCount()
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
        public void ShouldAdd()
        {
            Dictionary<string, int> referanceDictionary = new Dictionary<string, int>();
            MyDictionary<string, int> shouldNumbers = new MyDictionary<string, int>();

            referanceDictionary.Add("un", 1);
            shouldNumbers.Add("un", 1);
            Assert.AreEqual(referanceDictionary["un"], shouldNumbers["un"]);
            // Assert.That(MyList.RemoveAll().Length, Is.EqualTo(0));
        }

        [Test(Description = "Insert")]
        public void ShouldTryInsert()
        {
            Dictionary<string, int> referanceDictionary = new Dictionary<string, int>();
            MyDictionary<string, int> shouldNumbers = new MyDictionary<string, int>();

            referanceDictionary.Add("un", 1);
            shouldNumbers.Add("un", 1);
            Assert.Throws<Exception>(() => shouldNumbers.TryInsert("un", 2));
            Assert.AreEqual(referanceDictionary["un"], shouldNumbers["un"]);
        }

        [Test(Description = "RemoveFromNonEmpty")]
        public void ShouldRemveValue()
        {
            Dictionary<string, int> referanceNumbers = new Dictionary<string, int>();
            referanceNumbers.Add("un", 1);
            MyDictionary<string, int> shouldNumbers = new MyDictionary<string, int>();
            shouldNumbers.Add("un", 1);

            shouldNumbers.Remove("un");
            referanceNumbers.Remove("un");
            Assert.AreEqual(referanceNumbers.Count, shouldNumbers.Count);
        }

        [Test(Description = "remove whith save out value")]
        public void ShouldRemoveOutValue()
        {
            Dictionary<string, int> referanceNumbers = new Dictionary<string, int>();
            referanceNumbers.Add("un", 1);
            MyDictionary<string, int> shouldNumbers = new MyDictionary<string, int>();
            shouldNumbers.Add("un", 1);

            shouldNumbers.Remove("un", out int shouldInt);
            referanceNumbers.Remove("un", out int referanceInt);
            Assert.AreEqual(referanceNumbers.Count, shouldNumbers.Count);
            Assert.AreEqual(shouldInt, referanceInt);
        }
    }
}
