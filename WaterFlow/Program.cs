// See https://aka.ms/new-console-template for more information   /Users/beduroule/Documents/Code/FormationMargo/CsharpApprentice/Ile/Asset/
using System;

namespace WaterFlow;

class Program
{

    static void printBinary(BinaryTree root)
    {
        Console.Write($"{root.value}, ");
        if (root.left != null) {
            printBinary(root.left);
        }
        if (root.reight != null)
            printBinary(root.reight);
    }
    static void Main(string[] args)
    {
        FileDataSource fileDataSource = new FileDataSource("/Users/beduroule/Documents/Code/FormationMargo/CsharpApprentice/WaterFlow/Asset/FlowOne.txt");
        DataMap dataMap = fileDataSource.ReadFile();
        ResolveWaterFlow resolveWaterFlow = new ResolveWaterFlow(dataMap);

        Console.WriteLine($"H = {dataMap.Height}, W = {dataMap.Width}, O = {dataMap.Position}");
        Console.WriteLine();

        foreach (var elem in dataMap.PaltformRangeIndex) {
            Console.WriteLine($"Min = {elem.Min}, Max = {elem.Max}");
        }

        Console.WriteLine($"test i = {dataMap.PaltformRangeIndex[0].Min % dataMap.Width}, j = {dataMap.PaltformRangeIndex[0].Min / dataMap.Width}");
        Console.WriteLine($"Position i = {dataMap.Position % dataMap.Width}, j = {dataMap.Position / dataMap.Width}");

        var binaryTree = new BinaryTree();
        resolveWaterFlow.createBinaryTree(binaryTree, dataMap.Position, 0);
        Console.WriteLine();
        printBinary(binaryTree);



    }
}
