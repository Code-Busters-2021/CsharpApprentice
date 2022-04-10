namespace Chou
{
    public class MultithreadingWithoutPeasant
    {
        private StateEntitiesEnum Wolf = StateEntitiesEnum.LeftBank;
        private StateEntitiesEnum Cabbage = StateEntitiesEnum.LeftBank;
        private StateEntitiesEnum Goat = StateEntitiesEnum.LeftBank;
        private readonly object balanceLock = new object();

        public bool IsInTheSameState(StateEntitiesEnum entityOne, StateEntitiesEnum entityTwo)
        {
            // Console.WriteLine($"p = {Peasant}, G = {Goat}, C = {Cabbage}, W = {Wolf}");
            return (entityOne == StateEntitiesEnum.LeftBank && entityTwo == StateEntitiesEnum.LeftBank) || 
                    (entityOne == StateEntitiesEnum.RightBank && entityTwo == StateEntitiesEnum.RightBank) || 
                    (entityOne == StateEntitiesEnum.Boat && entityTwo == StateEntitiesEnum.Boat) && 
                    !(Wolf == StateEntitiesEnum.RightBank && Goat == StateEntitiesEnum.RightBank && Cabbage == StateEntitiesEnum.RightBank);
        }

        public bool IsFinish()
        {
            return Wolf == StateEntitiesEnum.RightBank && Goat == StateEntitiesEnum.RightBank && Cabbage == StateEntitiesEnum.RightBank;   
        }

        public void WolfFunc()
        {
            while (!IsFinish()) {
                lock (balanceLock) {
                    Console.WriteLine($"test lock 1 = {Wolf}");
                    if (IsInTheSameState(Wolf, Goat))
                        throw new Exception("The wolf ate the goat");
                }
            }
        }

        public void GoatFunc()
        {
            while (!IsFinish()) {
                lock (balanceLock) {
                    Console.WriteLine($"test lock 1 = {Goat}");
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
        }

        public void execute()
        {
            List<Task> tasks = new List<Task>() {new Task(GoatFunc), new Task(WolfFunc), new Task(CabbageFunc)};

            foreach (var task in tasks) {
                task.Start();
            }

            Console.WriteLine($"Wolf {Wolf} & Goat = {Goat} & Cabbage {Cabbage}");
            CrossRiver(ref Goat);
            CrossRiver(ref Wolf);
            Console.WriteLine($"Wolf {Wolf} & Goat = {Goat} & Cabbage {Cabbage}");
            CrossRiver(ref Goat);
            Console.WriteLine($"Wolf {Wolf} & Goat = {Goat} & Cabbage {Cabbage}");
            CrossRiver(ref Cabbage);
            Console.WriteLine($"Wolf {Wolf} & Goat = {Goat} & Cabbage {Cabbage}");
            CrossRiver(ref Goat);
            Console.WriteLine($"Wolf {Wolf} & Goat = {Goat} & Cabbage {Cabbage}");

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"fiish no peasant");
        }

    }
}