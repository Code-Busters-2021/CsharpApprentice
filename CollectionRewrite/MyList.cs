using System;
using System.Collections.Generic;

namespace test
{
    public class MyList<T>
    {
        private static int DefaultArraySize = 100;

        public T[] array = new T[DefaultArraySize];

        public T this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }

        private void ArrayCopy(T[] OriginalArray, T[] NewArray)
        {
            for (int i = 0; i < OriginalArray.Length - 1; i++) {
                NewArray[i] = OriginalArray[i];
            }
        }

        public void Add(T Item)
        {
            // Code
            if (array.Length > DefaultArraySize) {
                DefaultArraySize *= 2;
                T[] TmpArray = new T[DefaultArraySize];
                TmpArray[array.Length + 1] = Item;
                array = TmpArray;
            }
        }

        public void Remove(T Item)
        {
            int TmpIndex = Array.FindIndex(array, e => e.Equals(Item));
            if (TmpIndex == -1)
                return ;
            T[] TmpArray = new T[DefaultArraySize];
            
        }
    }
}