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

                    if (IsInTheSameState(Goat, Cabbage)) {
                        CrossRiver(ref Wolf);
                    }
                    // Console.WriteLine($"test lock 1 = {Wolf}");
                    // if (IsInTheSameState(Wolf, Goat) && !IsFinish())
                    //     throw new Exception("The wolf ate the goat");
                }
            }
        }

        public void GoatFunc()
        {
            while (!IsFinish()) {
                lock (balanceLock) {

                    if (IsInTheSameState(Goat, Cabbage)) {
                        CrossRiver(ref Goat);
                    }
                    // Console.WriteLine($"test lock 1 = {Goat}");
                    // if (IsInTheSameState(Goat, Cabbage) && !IsFinish())
                    //     throw new Exception($"The Goat ate the gabbage w: {Wolf},  W:{Goat}, C:{Cabbage} _::{IsFinish()}");
                }
            }
        } 

        public void CabbageFunc()
        {
            lock (balanceLock) {
                if (IsInTheSameState(Goat, Cabbage)) {
                    CrossRiver(ref Cabbage);
                }
            }
        }

        public void CrossRiver(ref StateEntitiesEnum element)
        {
            StateEntitiesEnum tmpElem = element;
            element = StateEntitiesEnum.Boat;
            Thread.Sleep(1000);
            element = tmpElem == StateEntitiesEnum.LeftBank ? StateEntitiesEnum.RightBank : StateEntitiesEnum.LeftBank;
            Console.WriteLine($"Wolf {Wolf} & Goat = {Goat} & Cabbage {Cabbage}");
        }

        public void execute()
        {
            List<Task> tasks = new List<Task>() {new Task(CabbageFunc), new Task(GoatFunc), new Task(WolfFunc)};

            foreach (var task in tasks) {
                task.Start();
            }

            // CrossRiver(ref Goat);
            // CrossRiver(ref Wolf);
            // CrossRiver(ref Goat);
            // CrossRiver(ref Cabbage);
            // CrossRiver(ref Goat);

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"fiish no peasant");
        }

    }
}