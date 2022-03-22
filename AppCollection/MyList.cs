using System;
using System.Collections.Generic;

namespace HelloWorld
{
    public class MyList<T>
    {
        public MyList(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new NullReferenceException("the colection is null");
            foreach (var elem in collection) {
                Add(elem);
            }
        }
        private static int DefaultArraySize = 2;
        private int length = 0;

        public int Length { get { return length; } }

        public T[] array = new T[DefaultArraySize];


        public T this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }

        public void Add(T Item)
        {
            if (length >= DefaultArraySize) {
                DefaultArraySize *= 2;
                T[] _array = new T[DefaultArraySize];
                Array.Copy(array, _array, length);
                _array[length++] = Item;
                array = _array;
            }
            else {
                array[length++] = Item;
            }
        }

        public void Insert (int index, T item)
        {
            if (length >= DefaultArraySize)
                DefaultArraySize *= 2;
            T[] _array = new T[DefaultArraySize];

            int indexOriginaleArray = 0;

            for (int i = 0; i < length + 1; i++) {
                if (indexOriginaleArray == index) {
                    _array[i] = item;
                    i++;
                    if (i >= length + 1)
                        break ;
                }
                _array[i] = array[indexOriginaleArray];
                indexOriginaleArray++;
            }
            array = _array;
            length++;
        }

        public void Remove(T Item)
        {
            int RemoveIndex = Array.FindIndex(array, e => e.Equals(Item));
            if (RemoveIndex == -1 || RemoveIndex > length)
                return ;
            T[] _array = new T[DefaultArraySize];

            int indexTmp = 0;

            for (int index = 0; index < length; index++) {
                if (index == RemoveIndex) {
                    continue ;
                }
                _array[indexTmp] = array[index];
                indexTmp++;
            }
            array = _array;
            length--;
        }

        public void RemoveAt (int index)
        {
            if (index < -1 || index > length)
                return ;
            T[] _array = new T[DefaultArraySize];

            int indexTmp = 0;

            for (int i = 0; i < length; i++) {
                if (i == index) {
                    continue ;
                }
                _array[indexTmp] = array[i];
                indexTmp++;
            }
            array = _array;
            length--;
        }

    }
}