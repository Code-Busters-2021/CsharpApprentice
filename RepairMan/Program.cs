using System;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

interface Machine
{
    public void Work();
}

public class CoffeeMachine : Machine
{
    public void Work()
    {
        MakeCoffee();
    }

    private void MakeCoffee()
    {
        System.Console.WriteLine("I'm a coffee machine and I'm making coffee");
    }
}

public class WashingMachine : Machine
{
    public Void Work()
    {
        System.Console.WriteLine("I'm a washing machine and I'm washing");
    }
}

public class RepairMan
{
    public static void Repair(Machine m)
    {
        System.Console.WriteLine("I'm repairing a strange machine");
    }
    public static void Repair(WashingMachine m)
    {
        System.Console.WriteLine("I'm repairing a strange machine");
    }
    public static void Repair(CoffeeMachine m)
    {
        System.Console.WriteLine("I'm repairing a strange machine");
    }
}
