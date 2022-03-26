namespace CollectionRewrite
{
    public class MyDictionaryNode<TKey, TValue>
    {
        public MyDictionaryNode() {}

        public MyDictionaryNode(TKey key, TValue value, MyDictionaryNode<TKey, TValue> next) 
        {
            this.key = key;
            this.value = value;
            this.next = next;
        }

        public MyDictionaryNode(TKey key, TValue value) 
        {
            this.key = key;
            this.value = value;
        }
        public TKey key;
        public TValue value;
        public MyDictionaryNode<TKey, TValue>? next;
    }
}