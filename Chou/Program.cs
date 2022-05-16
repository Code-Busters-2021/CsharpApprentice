namespace Chou 
{
    class Program
    {

        static async Task Main(string[] args)
        {
            MultithreadingSolution multithreadingSolution = new MultithreadingSolution();
            MultithreadingWithoutPeasant multithreadingWithoutPeasant = new MultithreadingWithoutPeasant();
            AsyncSolution asyncSolution = new AsyncSolution();
            MultithreadingNoLock multithreadingNoLock = new MultithreadingNoLock();

            multithreadingSolution.executeWithThreads();
            multithreadingWithoutPeasant.execute();
            multithreadingNoLock.execute();
            await asyncSolution.Execute();

        }
    }
}
