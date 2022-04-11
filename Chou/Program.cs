namespace Chou 
{
    class Program
    {

        static void Main(string[] args)
        {
            // MultithreadingSolution multithreadingSolution = new MultithreadingSolution();
            MultithreadingWithoutPeasant multithreadingWithoutPeasant = new MultithreadingWithoutPeasant();
            AsyncSolution asyncSolution = new AsyncSolution();
            // testNoP.execute();
            asyncSolution.Execute();

        }
    }
}
