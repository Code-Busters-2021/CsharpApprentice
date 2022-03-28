using System;
using System.Collections.Generic;

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
        private static int _length = 2;
        private int _count = 0;
        public int Count { get => _count; }
        int Length { get => _length; }

        public MyDictionaryNode<TKey, TValue>[] array = new MyDictionaryNode<TKey, TValue>[_length];

        public TValue this[TKey key]
        {
            get { return FindIndex(key).value; }
            set { Add(key, value); }
        }
        private int HashKey(TKey key)
        {
            int intKey;

            try {
                intKey = key.GetHashCode();
            }
            catch {
                throw new ArgumentException("Ivalide Key");
            }
            intKey = intKey < 0 ? intKey * -1 : intKey;
            return intKey % Length;
        }

        private void TryInsert(TKey key, TValue value)
        {
            int hashKey = HashKey(key);

            if (array[hashKey] == null)
                array[hashKey] = new MyDictionaryNode<TKey, TValue>(key, value);
            else {
                if (array[hashKey].next == null && Object.Equals(array[hashKey].key, key))
                    throw new ArgumentException($"this item as already been added: Key: {key}");
                MyDictionaryNode<TKey, TValue> node = array[hashKey];

                while (node.next != null) {
                    if (Object.Equals(node.key, key))
                        throw new ArgumentException($"this item as already been added: Key: {key}");
                    node = node.next;
                }
                node.next = new MyDictionaryNode<TKey, TValue>(key, value);
            }
            _count++;
        }

        private MyDictionaryNode<TKey, TValue> GetLastEelem(MyDictionaryNode<TKey, TValue> node)
        {
            while (node.next != null) {
                node = node.next;
            }
            return node;
        }

        public void Add(TKey key, TValue value)
        {
            TryInsert(key, value);
        }

        public void DisplayDictionary()
        {
            for (int i = 0; i < array.Length; i++) {
                if (array[i] == null) 
                    continue ;
                if (array[i].next == null)
                    Console.WriteLine($"key = {array[i].key}, value = {array[i].value}");
                else {
                    MyDictionaryNode<TKey, TValue> listNode = array[i];

                    while (listNode != null) {
                        Console.Write($"key = {listNode.key}, value = {listNode.value}, ");
                        listNode = listNode.next;
                    }
                    Console.WriteLine();
                }
            }
        }

        public MyDictionaryNode<TKey, TValue> Map(MyDictionaryNode<TKey, TValue> node, Func<TKey, bool> func)
        {
            while (node.next != null) {
                if (func(node.key))
                    return node;
                node = node.next;
            }
            return null;
        }
        public MyDictionaryNode<TKey, TValue> FindIndex(TKey key)
        {
            int hashKey = HashKey(key);

            if (array[hashKey].next == null)
                return array[HashKey(key)];
            return Map(array[hashKey], k => Object.Equals(k, key));
        }

        public void Remove(TKey key) 
        {
            int hashKey = HashKey(key);

            if (array[hashKey].next == null)
                array[hashKey] = null;
            else if (array[hashKey] != null) {
                MyDictionaryNode<TKey, TValue> previous = array[hashKey];
                MyDictionaryNode<TKey, TValue> tmpList = previous.next;
                
                Console.WriteLine("IN IN");
                while (tmpList.next != null) {
                    if (Object.Equals(tmpList.key, key) ) {
                        previous.next = tmpList.next;
                        tmpList = null;
                        return ;
                    }
                    previous = tmpList;
                    tmpList = tmpList.next;
                }
                Console.WriteLine("OUT OUT"); 
            }
        }

    }
}