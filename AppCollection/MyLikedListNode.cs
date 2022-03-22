using System;
using System.Collections.Generic;

namespace HelloWorld
{
    public class MyLikedListNode<T>
    {
        public T item;
        public MyLikedListNode<T>? next;
        public MyLikedListNode<T>? previus;
    }
}