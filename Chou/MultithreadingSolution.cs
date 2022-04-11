namespace Chou
{
    public class MultithreadingSolution
    {
        private StateEntitiesEnum Wolf = StateEntitiesEnum.LeftBank;
        private StateEntitiesEnum Cabbage = StateEntitiesEnum.LeftBank;
        private StateEntitiesEnum Goat = StateEntitiesEnum.LeftBank;
        private StateEntitiesEnum Peasant = StateEntitiesEnum.LeftBank;
        private readonly object balanceLock = new object();

        public bool IsInTheSameState(StateEntitiesEnum entityOne, StateEntitiesEnum entityTwo)
        {
            // Console.WriteLine($"p = {Peasant}, G = {Goat}, C = {Cabbage}, W = {Wolf}");
            return (entityOne == StateEntitiesEnum.LeftBank && entityTwo == StateEntitiesEnum.LeftBank && Peasant != StateEntitiesEnum.LeftBank) || 
                    (entityOne == StateEntitiesEnum.RightBank && entityTwo == StateEntitiesEnum.RightBank && Peasant != StateEntitiesEnum.RightBank) || 
                    (entityOne == StateEntitiesEnum.Boat && entityTwo == StateEntitiesEnum.Boat && Peasant != StateEntitiesEnum.Boat);
        }

        public bool IsFinish()
        {
            return Wolf == StateEntitiesEnum.RightBank && Goat == StateEntitiesEnum.RightBank && Cabbage == StateEntitiesEnum.RightBank && Peasant == StateEntitiesEnum.RightBank;   
        }

        public void WolfFunc()
        {
            while (!IsFinish()) {
                lock (balanceLock) {
                    if (IsInTheSameState(Wolf, Goat))
                        throw new Exception("The wolf ate the goat");
                }
            }
        }

        public void GoatFunc()
        {
            while (!IsFinish()) {
                lock (balanceLock) {
                    if (IsInTheSameState(Goat, Cabbage))
                        throw new Exception("The Goat ate the gabbage");
                }
            }
        } 

        public void CabbageFunc()
        {
        }

        public void CrossRiver(ref StateEntitiesEnum element)
        {
            StateEntitiesEnum tmpElem = element;
            element = StateEntitiesEnum.Boat;
            Thread.Sleep(1000);
            element = tmpElem == StateEntitiesEnum.LeftBank ? StateEntitiesEnum.RightBank : StateEntitiesEnum.LeftBank;
            Console.WriteLine($"Wolf {Wolf} & Goat = {Goat} & Cabbage {Cabbage} & p = {Peasant}");
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

        public void execute()
        {
            List<Task> tasks = new List<Task>() {new Task(GoatFunc), new Task(WolfFunc), new Task(CabbageFunc), new Task(PeasantFunc)};

            foreach (var task in tasks) {
                task.Start();
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"finish multithreading");
            Console.WriteLine();
        }

    }
}