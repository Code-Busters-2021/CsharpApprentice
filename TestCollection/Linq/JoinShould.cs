using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;
using System.Linq;


namespace TestCollection.Linq
{
    [TestFixture]
    public class JoinShould
    {
        List<ObjectOne> objectOnes = new List<ObjectOne>();
        List<ObjectTwo> objectTwos = new List<ObjectTwo>();

        [SetUp]
        public void Setup()
        {
            for (int i = 0; i < 10; i++) {
                objectOnes.Add(new ObjectOne(i, $"One {i.ToString()}"));
            }
            for (int i = 7; i < 20; i++) {
                objectTwos.Add(new ObjectTwo(i, $"Two {i.ToString()}"));
            }
        }

        [Test(Description = "number")]
        public void SimpleJoinShould()
        {
            var resultAfterJoin = objectOnes.Join(objectTwos, one => one.Id, two => two.Id, (one, two) =>  new { oneName = one.OneName, twoName = two.TwoName });

            object[] expectedResult = new object[] { 
                new {oneName = "One 7", twoName = "Two 7"},
                new {oneName = "One 8", twoName = "Two 8"},
                new {oneName = "One 9", twoName = "Two 10"},
            };
            CollectionAssert.AreEqual(expectedResult, resultAfterJoin, $"where doesn't work");
        }

                [Test(Description = "number")]
        /*public void CompositeJoinShould()
        {
            var resultAfterJoin = objectOnes.Join(objectTwos,
                one => one.Id,
                two => two.Id,
                (one, two) =>  new { oneName = one.OneName, twoName = two.TwoName });

            object[] expectedResult = new object[] { 
                new {oneName = "One 7", twoName = "Two 7"},
                new {oneName = "One 8", twoName = "Two 8"},
                new {oneName = "One 9", twoName = "Two 10"},
            };
            CollectionAssert.AreEqual(expectedResult, resultAfterJoin, $"where doesn't work");
        }*/

        private class ObjectOne
        {
            public ObjectOne(int Id, string Name) {
                this.Id = Id;
                this.OneName = Name;
            }
            public int Id { get; set; }
            public string OneName { get; set;}
        }

        private class ObjectTwo
        {
            public ObjectTwo(int Id, string Name) {
                this.Id = Id;
                this.TwoName = Name;
            }
            public int Id { get; set; }
            public string TwoName { get; set;}
        }

    }
}
