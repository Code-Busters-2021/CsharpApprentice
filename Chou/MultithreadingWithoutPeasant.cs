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
                    (entityOne == StateEntitiesEnum.RightBank && entityTwo == StateEntitiesEnum.RightBank);
        }

        public bool IsFinish()
        {
            return Wolf == StateEntitiesEnum.RightBank && Goat == StateEntitiesEnum.RightBank && Cabbage == StateEntitiesEnum.RightBank;
        }

        public bool IsStart()
        {
            return Wolf == StateEntitiesEnum.LeftBank && Goat == StateEntitiesEnum.LeftBank && Cabbage == StateEntitiesEnum.LeftBank;
        }

        public void WolfFunc()
        {
            while (!IsFinish()) {
                lock (balanceLock) {
                    if (IsInTheSameState(Wolf, Goat) && !IsStart() && !IsFinish())
                        throw new Exception("The wolf ate the goat");
                }
            }
        }

        public void GoatFunc()
        {
            while (!IsFinish()) {
                lock (balanceLock) {
                    if (IsInTheSameState(Goat, Cabbage) && !IsStart() && !IsFinish())
                        throw new Exception($"The Goat ate the gabbage w: {Wolf},  W:{Goat}, C:{Cabbage} _Finish::{IsFinish()}, __Start{IsStart()} ");
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
            Console.WriteLine($"Wolf {Wolf} & Goat = {Goat} & Cabbage {Cabbage}");
        }

        public void ChangeSates(ref StateEntitiesEnum element, StateEntitiesEnum state)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Wolf {Wolf} & Goat = {Goat} & Cabbage {Cabbage}");
            element = state; 
        }

        public void execute()
        {
            List<Task> tasks = new List<Task>() {new Task(CabbageFunc), new Task(GoatFunc), new Task(WolfFunc)};

            foreach (var task in tasks) {
                task.Start();
            }

            CrossRiver(ref Goat);
            ChangeSates(ref Wolf, StateEntitiesEnum.Boat);
            ChangeSates(ref Goat, StateEntitiesEnum.Boat);
            ChangeSates(ref Wolf, StateEntitiesEnum.RightBank);
            CrossRiver(ref Cabbage);
            ChangeSates(ref Goat, StateEntitiesEnum.RightBank);

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"fiish no peasant");
        }

    }
}