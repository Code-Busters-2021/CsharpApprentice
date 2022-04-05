using System;

namespace CollectionRewrite
{
    public interface IMyList<T>
    {
        void Add(T Item);
        void Visit(Action<T> function);
    }
}