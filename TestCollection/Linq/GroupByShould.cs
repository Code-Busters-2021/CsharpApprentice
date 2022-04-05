using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;
using System.Linq;


namespace TestCollection.Linq
{
    [TestFixture]
    public class GroupByShould
    {
        List<ObjectOne> objectOnes = new List<ObjectOne>() {};

        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "number")]
        public void SimpleJoinShould()
        {
            List<ObjectOne> objectOnes = new List<ObjectOne>() { 
                new ObjectOne(1, "one"),
                new ObjectOne(3, "one"),
                new ObjectOne(1, "two"),
                new ObjectOne(5, "two"),
                new ObjectOne(1, "tree")
            };
            var resultAfterJoin = objectOnes.GroupBy(obj => obj.OneName, obj => obj.Id, (baseObj, obj) => new {
                Key = baseObj,
                Count = obj.Count(),
            });

            object[] expectedResult = new object[] { 
                new {oneName = "One 7", twoName = "Two 7"},
                new {oneName = "One 8", twoName = "Two 8"},
                new {oneName = "One 9", twoName = "Two 10"},
            };
            CollectionAssert.AreEqual(expectedResult, resultAfterJoin, $"where doesn't work");
        }

        // [Test(Description = "number")]
        // public void CompositeJoinShould()
        // {
        //     var resultAfterJoin = objectOnes.Join(objectTwos,
        //         one => one.Id,
        //         two => two.Id,
        //         (one, two) =>  new { oneName = one.OneName, twoName = two.TwoName });

        //     object[] expectedResult = new object[] { 
        //         new {oneName = "One 7", twoName = "Two 7"},
        //         new {oneName = "One 8", twoName = "Two 8"},
        //         new {oneName = "One 9", twoName = "Two 10"},
        //     };
        //     CollectionAssert.AreEqual(expectedResult, resultAfterJoin, $"where doesn't work");
        // }

        private class ObjectOne
        {
            public ObjectOne(int Id, string Name) {
                this.Id = Id;
                this.OneName = Name;
            }
            public int Id { get; set; }
            public string OneName { get; set;}
        }

    }
}
