using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionRewrite
{
    public class InvertedEnumerable : IEnumerable<double>
    {
        public static IEnumerable<double> InvertNumbers(IEnumerable<int> originalEnumerable) => new InvertedEnumerable(originalEnumerable);

        private readonly IEnumerable<int> _originalEnumerable;

        public InvertedEnumerable(IEnumerable<int> originalEnumerable)
        {
            _originalEnumerable = originalEnumerable;
        }

        public IEnumerator<double> GetEnumerator()
        {
            return new InvertedEnumerator(_originalEnumerable.GetEnumerator());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class InvertedEnumerator : IEnumerator<double>
        {
            private readonly IEnumerator<int> _originalValues;

            public InvertedEnumerator(IEnumerator<int> originalValues)
            {
                _originalValues = originalValues;
            }
            public bool MoveNext() => _originalValues.MoveNext();

            public void Reset()
            {
                _originalValues.Reset();
            }

            public double Current => 1d / _originalValues.Current ;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                Reset();
            }
        }
    }
}
