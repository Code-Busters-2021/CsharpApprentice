using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionRewrite 
{
    public class MyDictionary<TKey, TValue>
    {
        // TODO add generic parcour 
        // TODO verif hash unique

        public MyDictionary() {}

        public MyDictionary(TKey key) {
            Console.WriteLine(HashKey(key));
        }
        private static int _length = 100;
        private int _count = 0;
        public int Count { get => _count; }
        int Length { get => _length; }

        public CollisionsList<TKey, TValue>[] array = new CollisionsList<TKey, TValue>[_length];

        public TValue this[TKey key]
        {
            get { return FindIndex(key).Value; }
            set { Add(key, value); }
        }
        private int HashKey(TKey key)
        {
            int intKey;

            try {
                intKey = key.GetHashCode();
            }
            catch(Exception e) {
                throw new ArgumentException("Invalid Key", e);
            }
            intKey = intKey < 0 ? intKey * -1 : intKey;
            return intKey % Length;
        }

        public void TryInsert(TKey key, TValue value)
        {
            int hashKey = HashKey(key);
            if (array[hashKey] == null)
                array[hashKey] = new CollisionsList<TKey, TValue>(key, value);
            else {
                foreach (var sameKeyValue in array[hashKey])
                {
                    if (ReferenceEquals(sameKeyValue.Key, key))
                    {
                        throw new ArgumentException($"this item as already been added: Key: {key}");
                    }
                }
                array[hashKey]?.Add((key, value));
            }
            _count++;
        }

        public void Add(TKey key, TValue value)
        {
            TryInsert(key, value);
        }

        public void DisplayDictionary()
        {
            foreach (CollisionsList<TKey, TValue> collisionsList in array)
            {
                if (collisionsList == null) {
                    continue;
                }

                foreach (var listNode in collisionsList) {
                    Console.Write($"key = {listNode.Key}, value = {listNode.Value}, ");
                }

                Console.WriteLine();
            }
        }

        public (TKey Key, TValue Value) FindIndex(TKey key)
        {
            int hashKey = HashKey(key);

            foreach (var tuple in array[hashKey]) {
                if (Equals(tuple.Key,key)) {
                    return tuple;
                }
            }

            throw new KeyNotFoundException($"Key '{key}' does not exist");
        }

        public void Remove(TKey key)
        {
            int hashKey = HashKey(key);

            array[hashKey].Remove(key);
        }

        public void Remove(TKey key, out TValue value)
        {
            int hashKey = HashKey(key);
            value = array[hashKey].Value;

            array[hashKey].Remove(key);
        }

    }
}
