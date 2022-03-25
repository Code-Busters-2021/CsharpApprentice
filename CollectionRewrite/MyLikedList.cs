using System;
using System.Collections.Generic;

namespace CollectionRewrite
{
    // TODO add construct default
    public class MyLikedList<T>
    {
        public MyLikedList() {}
        public MyLikedList(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new NullReferenceException("the colection is null");
            foreach (var elem in collection) {
                AddLast(elem);
            }
        }
        MyLikedListNode<T> Head;

        public int Count { get;  private set; }
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

        public void Visit(Action<T> function)
        {
            MyLikedListNode<T> _head = Head;

             while (_head.next != null) {
                function(_head.item);
                _head = _head.next;
            }
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
            Count++;
        }

        private void InitEmptyList(T item)
        {
            Head = CreatElem(item, null, null);
        }
    
        private bool IsEmpty => Head == null;


        public void AddFirst(T item)
        {
            if (IsEmpty) {
                InitEmptyList(item);
            }
            else {
                MyLikedListNode<T> _head = Head;
                Head = CreatElem(item, null, _head); // Head = CreatElem(item, GetLastElem(), _head);
            }
            Count++;
        }

        // TODO methode parcourire reverse + use Last
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
            Count++;
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