using System;
using System.Collections.Generic;

// ! define resize method print reverse 

namespace CollectionRewrite
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
        private static int RangeArraySize = 2;
        private static int ArraySize = 2;
        private int length = 0;

        public int Length { get { return length; } }

        public T[] array = new T[ArraySize];


        public T this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }

        public void Resize()
        {
            ArraySize += RangeArraySize;
            T[] _array = new T[ArraySize];
            Array.Copy(array, _array, length);
            array = _array;
        } 

        public void Add(T Item)
        {
            if (length >= ArraySize) {
                Resize();
                array[length++] = Item;
            }
            else {
                array[length++] = Item;
            }
        }

        // TODO refacto Array.cpy()
        public void Insert (int index, T item)
        {
            if (length >= ArraySize)
                ArraySize += RangeArraySize;
            T[] _array = new T[ArraySize];

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

        public void Reverse()
        {
            T[] _array = new T[ArraySize];
            // TODO add size

            for (int i = 0; i < length; i++) {
                _array[length - 1 - i] = array[i];
            }
            array = _array;
        }

        // public void BrowseArray(Delegate met)

        public void Print()
        {
            foreach (var elem in array) {
                Console.WriteLine($"{elem}, ");
            }
        }

        // TODO refacto Array.cpy()
        public void Remove(T Item)
        {
            int RemoveIndex = Array.FindIndex(array, e => e.Equals(Item));
            if (RemoveIndex == -1 || RemoveIndex > length)
                return ;
            T[] _array = new T[ArraySize];

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
            T[] _array = new T[ArraySize];

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