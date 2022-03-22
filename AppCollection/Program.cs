using System;
using System.Text;
using System.Collections.Generic;

namespace HelloWorld
{
    class Program
    {
        public static async void testList(List<int> list, MyList<int> myList, string message)
        {
            Console.WriteLine(message);
            if (list.Count == myList.Length) 
                Console.WriteLine("length OK");
            else 
                Console.WriteLine("length KO");
            for (int i = 0; i < list.Count; i++) {
                Console.WriteLine($"test list {list[i]}, test myList: {myList[i]}");
            }
            Console.Write("\n\n");
        }

        public static void MtestList()
        {
            MyList<int> myList = new MyList<int>(new int[] {1, 2, 5, 2, 2});
            List<int> list = new List<int>() {1, 2, 5, 2, 2};

            testList(list, myList, "test Add");

            list.Remove(2);
            myList.Remove(2);

            testList(list, myList, "test remove");

            list.RemoveAt(1);
            myList.RemoveAt(1);

            testList(list, myList, "test remove At");


            list.Insert(2, 6);
            myList.Insert(2, 6);

            testList(list, myList, "test Insert");
        }

        public static void testUnit(MyLikedList<int> myList, LinkedList<int> list)
        {
            Console.WriteLine($"list count: {list.Count}, MyList c: {myList.Count}");
            foreach (var elem in list) {
                Console.Write($"{elem}->");
            }
            Console.WriteLine();
            myList.PrintList();
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void testLickedList()
        {
            LinkedList<int> list = new LinkedList<int>(new int[] {1, 3, 5, 3, 4, 5});
            MyLikedList<int> myList = new MyLikedList<int>(new int[] {1, 3, 5, 3, 4, 5});

            testUnit(myList, list);

            list.AddLast(9);
            myList.AddLast(9);
            testUnit(myList, list);

            list.AddFirst(11);
            myList.AddFirst(11);
            testUnit(myList, list);

            list.RemoveFirst();
            myList.RemoveFirst();
            testUnit(myList, list);

            list.RemoveLast();
            myList.RemoveLast();
            testUnit(myList, list);
        }
        static void Main(string[] args)
        {
            // MtestList();
            testLickedList();

        }
    }
}