using System;

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
        int Length { get => _length; set => value = 100; }
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
                // key.ToString();
            }
            catch {
                throw new ArgumentException("Ivalide Key");
            }
            intKey = intKey < 0 ? intKey * -1 : intKey;
            return intKey % Length;
        }

        private void TryInsert(TKey key, TValue value, MyDictionaryNode<TKey, TValue> node)
        {
            while (node.next != null) {
                if (Object.Equals(node.key, key))
                    throw new ArgumentException($"this item as already been added: Key: {key}");
                node = node.next;
            }
        }

        public void Add(TKey key, TValue value)
        {
            int hashKey = HashKey(key);
            if (!object.ReferenceEquals(null, array[hashKey])) {
                MyDictionaryNode<TKey, TValue> listNode = array[hashKey];

                while (listNode.next != null) {
                    listNode = listNode.next;
                }
                listNode.next = new MyDictionaryNode<TKey, TValue>(key, value);
            } else {
                array[hashKey] =  new MyDictionaryNode<TKey, TValue>(key, value);
            }
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
                }
            }
        }

        public MyDictionaryNode<TKey, TValue> FindIndex(TKey key)
        {
            for (int i = 0; i < array.Length; i++) {
                if (Object.Equals(array[i].key, key))
                    return array[i];
                else if (array[i].next != null) {
                    MyDictionaryNode<TKey, TValue> listNode = array[i];

                    while (listNode.next != null) {
                        if (Object.Equals(listNode.key, key))
                            return listNode;
                        listNode = listNode.next;
                    }
                }
            }
            return null;
        }

    }
}