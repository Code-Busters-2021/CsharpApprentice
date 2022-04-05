using System;
using System.Diagnostics;


namespace Prog
{
    class Program
    {

        static Machine CreateMachine()
        {
            if (DateTime.Now.Hour < 8)
            {
                return new CoffeeMachine();
            }

            return new WashingMachine();

        }

        public static void Main(string[] args)
        {

            // See https://aka.ms/new-console-template for more information
            Console.WriteLine("Hello, World!");

            RepairMan.Repair(CreateMachine());
        }
    }

    public interface Machine
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
        public void Work()
        {
            System.Console.WriteLine("I'm a washing machine and I'm washing");
        }
    }

    public class RepairMan
    {
        public static void Repair(Machine m)
        {
            var resul = m switch
            {
                CoffeeMachine cm => Repair(cm),
                WashingMachine wm => Repair(wm),
                _ => throw new Exception($"Unknown Machine type {m.GetType()}")
            };

          
        }

        public static bool Repair(WashingMachine m)
        {
            System.Console.WriteLine("I'm repairing a washing machine");
            return true;
        }

        public static bool Repair(CoffeeMachine m)

        {
            Console.WriteLine("I'm repairing a coffee machine");
            return true;
        }
    }
}
