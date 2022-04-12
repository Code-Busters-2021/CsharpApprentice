namespace Chou
{
    public class MultithreadingSolution
    {
        private StateEntitiesEnum Wolf = StateEntitiesEnum.LeftBank;
        private StateEntitiesEnum Cabbage = StateEntitiesEnum.LeftBank;
        private StateEntitiesEnum Goat = StateEntitiesEnum.LeftBank;
        private StateEntitiesEnum Peasant = StateEntitiesEnum.LeftBank;
        private readonly object balanceLock = new object();

        public bool AreInTheSamePlace(StateEntitiesEnum entityOne, StateEntitiesEnum entityTwo)
        {
            return entityOne == entityTwo && Peasant != entityOne;
        }

        public bool IsFinish()
        {
            return Wolf    == StateEntitiesEnum.RightBank
                && Goat    == StateEntitiesEnum.RightBank
                && Cabbage == StateEntitiesEnum.RightBank
                && Peasant == StateEntitiesEnum.RightBank;   
        }

        public void WolfFunc()
        {
            while (!IsFinish()) {
                lock (balanceLock) {
                    if (AreInTheSamePlace(Wolf, Goat))
                        throw new Exception("The wolf ate the goat");
                }
            }
        }

        public void GoatFunc()
        {
            while (!IsFinish()) {
                lock (balanceLock) {
                    if (AreInTheSamePlace(Goat, Cabbage))
                        throw new Exception("The Goat ate the cabbage");
                }
            }
        } 

        public void CabbageFunc()
        {
            if (!IsFinish()) 
                Console.WriteLine("I'm a Cabbage");
        }
        public void PeasantFunc()
        {
            CrossRiver(ref Wolf);
            CrossRiver(ref Cabbage);
            CrossRiver(ref Peasant);
            CrossRiver(ref Peasant);
            CrossRiver(ref Peasant);
            CrossRiver(ref Goat);
        }

        public void CrossRiver(ref StateEntitiesEnum element)
        {
            StateEntitiesEnum tmpElem = element;
            element = StateEntitiesEnum.Boat;
            Thread.Sleep(1000);
            element = tmpElem == StateEntitiesEnum.LeftBank ? StateEntitiesEnum.RightBank : StateEntitiesEnum.LeftBank;
            Console.WriteLine($"Wolf {Wolf} & Goat = {Goat} & Cabbage {Cabbage} & p = {Peasant}");
        }


        public void executeWithThreads()
        {
            Thread[] threads = new[]
            {
                new Thread(GoatFunc),
                new Thread(WolfFunc),
                new Thread(CabbageFunc),
                new Thread(PeasantFunc)
            };



            foreach (var thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine($"finish multithreading");
            Console.WriteLine();
        }

        public void executeWithTasks()
        {
            var tasks = new[]
            {
                Task.Factory.StartNew(GoatFunc),
                Task.Factory.StartNew(WolfFunc),
                Task.Factory.StartNew(CabbageFunc),
                Task.Factory.StartNew(PeasantFunc)
            };
            Task.WaitAll(tasks);

            Console.WriteLine($"finish multithreading");
            Console.WriteLine();
        }
    }
    }
