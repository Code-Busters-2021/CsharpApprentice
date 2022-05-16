namespace Ile 
{
    class Program
    {

        static void Main(string[] args)
        {
            ParsingMap parsingMap = new ParsingMap("/Users/beduroule/Documents/Code/FormationMargo/CsharpApprentice/Ile/Asset/Interedierap.txt");
            Map map = new Map(parsingMap.ReadFile());

            Console.WriteLine( $" Count Island :: {map.CountIsland()}");
            Console.WriteLine();
            Console.WriteLine();
            int[][] tab = parsingMap.ReadFile();

            foreach (var i in tab) {
                foreach (var elem in i) {
                    Console.Write($"{elem}");
                }
                Console.WriteLine();
            }
        }
    }
}
