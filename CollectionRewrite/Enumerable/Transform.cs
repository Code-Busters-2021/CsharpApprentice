using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionRewrite.Enumerable
{
    static class Transformer
    {
        public static IEnumerable<TResult> TransformNumbers<TInput,TResult>(IEnumerable<TInput> originalEnumerable, Func<TInput, TResult> transformFunc)
        {
            return new TransformedEnumerable<TInput,TResult>(originalEnumerable, transformFunc);
        }
    }
    public class TransformedEnumerable<TInput, TResult> : IEnumerable<TResult>
    {
        private readonly TransformedEnumerator _transformedEnumerator;

        public TransformedEnumerable(IEnumerable<TInput> originalEnumerable, Func<TInput, TResult> transformFunc)
        {
            _transformedEnumerator = new TransformedEnumerator(originalEnumerable.GetEnumerator(), transformFunc);
        }

        public IEnumerator<TResult> GetEnumerator() => _transformedEnumerator;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class TransformedEnumerator : IEnumerator<TResult>
        {
            private readonly IEnumerator<TInput> _originalValues;
            private readonly Func<TInput, TResult> _transformFunc;

            public TransformedEnumerator(IEnumerator<TInput> originalValues, Func<TInput, TResult> transformFunc)
            {
                _originalValues = originalValues;
                _transformFunc = transformFunc;
            }
            public bool MoveNext() => _originalValues.MoveNext();

            public void Reset()
            {
                _originalValues.Reset();
            }

            public TResult Current => _transformFunc(_originalValues.Current) ;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                Reset();
            }
        }
    }
}
