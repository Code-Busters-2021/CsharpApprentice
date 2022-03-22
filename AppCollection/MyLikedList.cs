using System;
using System.Collections.Generic;

namespace HelloWorld
{
    public class MyLikedList<T>
    {
        public MyLikedList(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new NullReferenceException("the colection is null");
            foreach (var elem in collection) {
                AddLast(elem);
            }
        }
        MyLikedListNode<T> Head;

        private int count = 0;

        public int Count { get { return count;} }
        public MyLikedListNode<T>  First { get {return Head; } }
       //  public MyLikedListNode<T>  Last { get { GetLastElem(); } }

        protected MyLikedListNode<T> CreatElem(T item, MyLikedListNode<T> prev, MyLikedListNode<T> next)
        {
            MyLikedListNode<T> elem = new MyLikedListNode<T>();
            elem.item = item;
            elem.next = next;
            elem.previus = prev;
            return elem;
        }
        public MyLikedListNode<T> GetLastElem()
        {
            MyLikedListNode<T> _head = Head;

            while (_head.next != null) {
                _head = _head.next;
            }
            return _head;
        }
        public void AddLast(T item)
        {
            if (Head == null) {
                Head = CreatElem(item, null, null);
            }
            else {
                MyLikedListNode<T> _head = Head;

                while (_head.next != null) {
                    _head = _head.next;
                }
                _head.next = CreatElem(item, _head, null);
            }
            count++;
        }

        public void AddFirst(T item)
        {
            if (Head == null) {
                Head = CreatElem(item, null, null);
            }
            else {
                MyLikedListNode<T> _head = Head;
                Head = CreatElem(item, null, _head); // Head = CreatElem(item, GetLastElem(), _head);
            }
            count++;
        }

        public async void PrintList()
        {
            MyLikedListNode<T> _head = Head;
            while (_head != null) {
                if (_head.next == null)
                    Console.Write($"{_head.item}");
                else
                    Console.Write($"{_head.item}->");
                _head = _head.next;
            }
            Console.WriteLine();
        }

        public void RemoveFirst()
        {
            if (Head == null)
                throw new NullReferenceException("the list is null");
            if (Head.next == null)
                Head = null;
            else {
                MyLikedListNode<T> _head = Head;
                _head = Head.next;
                _head.previus = null;
                Head = null;
                Head = _head;
            }
            count++;
        }

        public void RemoveLast()
        {
            if (Head == null)
                throw new NullReferenceException("the list is null");
            if (Head.next == null)
                Head = null;
            else {
                MyLikedListNode<T> lastElem = GetLastElem().previus;
                // lastElem.next = null;
                Console.WriteLine($"last :: {lastElem.item}");
                lastElem.next = null;
            }
        }

    }
}