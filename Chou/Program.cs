namespace Chou 
{
    class Program
    {

        static async Task Main(string[] args)
        {
            // MultithreadingSolution multithreadingSolution = new MultithreadingSolution();
            MultithreadingWithoutPeasant multithreadingWithoutPeasant = new MultithreadingWithoutPeasant();
            AsyncSolution asyncSolution = new AsyncSolution();
            // testNoP.execute();
            await asyncSolution.Execute();

        }
    }
}
