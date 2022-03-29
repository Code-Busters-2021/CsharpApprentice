using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionRewrite
{
    public class CollisionsList<TKey, TValue> : ICollection<(TKey Key, TValue Value)> 
    {
        private readonly ICollection<(TKey Key, TValue Value)> _internalList = new LinkedList<(TKey Key, TValue Value)>();

        public CollisionsList()
        {
            
        }
        public CollisionsList(TKey key, TValue val)
        {
            _internalList = new LinkedList<(TKey Key, TValue Value)>(new[] { (key, val) });
        }
        public IEnumerator<(TKey Key, TValue Value)> GetEnumerator()
        {
            return _internalList.GetEnumerator();
        }

        public TKey Key => _internalList.GetEnumerator().Current.Key;
        public TValue Value => _internalList.GetEnumerator().Current.Value;
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _internalList).GetEnumerator();
        }

        public void Add((TKey Key, TValue Value) item)
        {

            _internalList.Add(item);
        }

        public void Clear()
        {
            _internalList.Clear();
        }

        public bool Contains((TKey Key, TValue Value) item)
        {
            return _internalList.Contains(item);
        }

        public void CopyTo((TKey Key, TValue Value)[] array, int arrayIndex)
        {
            _internalList.CopyTo(array, arrayIndex);
        }

        public bool Remove((TKey Key, TValue Value) item)
        {
            return _internalList.Remove(item);
        }
        public bool Remove(TKey key)
        {
            var item = _internalList.Where(tuple => tuple.Key.Equals(key)).ToArray();
            if (item .Length == 0)
            {
                return false;
            }
            return _internalList.Remove(item[0]);
        }

        public int Count => _internalList.Count;

        public bool IsReadOnly => false;
    }
}
