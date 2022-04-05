using System;
using System.Text;
using System.Collections.Generic;
using CollectionRewrite;

namespace CollectionRewrite
{
    class Program
    {
        public class testClass
        {
            public int test;
        }
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

            list.Reverse();
            myList.Reverse();
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
            IEnumerable<string> strs = new string[] {"tata", "toto", "tut", "AaA", "a z", "A Z"};
            Console.WriteLine("_________________________ List ________________________");
            MtestList();
            Console.WriteLine("_____________________ Liked List ______________________");
            testLickedList();

            var t = strs.OrderBy(s => s[2]).ToList();
            foreach (var elem in t) {
                Console.WriteLine(elem);
            }

            string testStr = "un";
            MyDictionary<string, int> test = new MyDictionary<string, int>(testStr);
            test.Add("zero", 0);
            test.Add("un", 1);
            test.Add("deux", 2);
            test.Add("trois", 4);
            test["coucou"] = 8;

             Console.WriteLine($"before remove: {test["coucou"]}");
            test.Remove("coucou");
            // Console.WriteLine($"before remove: {test["coucou"]}");

            test.DisplayDictionary();
            // Console.WriteLine($"test = {test["deux"]}");
 

            // Dictionary<string, int> test = new Directory<string, int>();
        }
    }
}