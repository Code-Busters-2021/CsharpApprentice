using System;
using System.Collections.Generic;

namespace CollectionRewrite
{
    public class MyLikedListNode<T>
    {
        public MyLikedListNode() {}

        public T item { get; set; }
        public MyLikedListNode<T>? next  { get; set; }
        public MyLikedListNode<T>? previus  { get; set; }
    }
}