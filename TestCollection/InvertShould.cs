using System;
using NUnit.Framework;
using CollectionRewrite;
using System.Collections.Generic;
using System.Linq;
using CollectionRewrite.Enumerable;

namespace TestCollection
{
    [TestFixture]
    public class InvertShould
    {
        [SetUp]
        public void Setup()
        {
     
        }

        [Test(Description = "TestInvert")]
        public void TestAdd()
        {
            // Assert.That(MyList.RemoveAll().Length, Is.EqualTo(0));
        }

        [Test]
        public void TestAreEqualForEveryNumber()
        {

            IEnumerable<int> numbers = new[] {0, 1, 2, 3, 4, 5, 6};
            IEnumerable<double> invertedNumbers = InvertedEnumerable.InvertNumbers(numbers);

            IEnumerable<double> invertedWithSelect = numbers.Select(x => 1d / x);
            var selectEnumerator = invertedWithSelect.GetEnumerator();
            var myEnumerator = invertedNumbers.GetEnumerator();
            while (selectEnumerator.MoveNext() && myEnumerator.MoveNext())
            {
                Assert.AreEqual(selectEnumerator.Current, myEnumerator.Current);
            }

            Console.WriteLine(string.Join(", ", invertedNumbers));
        }
        [Test]
        public void TestIEnumerableDifferedExecution()
        {

            IEnumerable<int> numbers = new[] { 1, 2, 3, 4, 5, 6, 0};

            IEnumerable<double> invertedWithSelect = Transformer.TransformNumbersWithYield(numbers,
                (i => i == 0 ? throw new Exception("Division by zero") : 1d/i));
            while (invertedWithSelect.GetEnumerator().MoveNext())
            {
                var d = invertedWithSelect.GetEnumerator().Current;
                
                Console.WriteLine(d);
                if (d == 1d / 3)
                {
                    break;
                }
            }

            Console.WriteLine("Interlude");

            foreach (var d in invertedWithSelect)
            {
                Console.WriteLine(d);
            }
        }
        [Test]
        public void TestInvertedEnumerable()
        {
            IEnumerable<int> numbers = new[] {1, 2, 3, 4, 5, 6};
            IEnumerable<double> invertedNumbers = InvertedEnumerable.InvertNumbers(numbers);

            IEnumerable<double> invertedWithSelect = numbers.Select(x => 1d / x);
            CollectionAssert.AreEqual(invertedWithSelect, invertedNumbers, $"{nameof(InvertedEnumerable)} doesn't work");
        }

        public void CeciNestPasUnTest()
        {

        }
    }
}
