namespace Chou
{
    class AsyncSolution
    {
        private StateEntitiesEnum Wolf = StateEntitiesEnum.LeftBank;
        private StateEntitiesEnum Cabbage = StateEntitiesEnum.LeftBank;
        private StateEntitiesEnum Goat = StateEntitiesEnum.LeftBank;

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

        public async Task CrossRiver(ref StateEntitiesEnum element)
        {
            StateEntitiesEnum tmpElem = element;
            element = StateEntitiesEnum.Boat;
            await Thread.Sleep(1000);
            element = tmpElem == StateEntitiesEnum.LeftBank ? StateEntitiesEnum.RightBank : StateEntitiesEnum.LeftBank;
            Console.WriteLine($"Wolf {Wolf} & Goat = {Goat} & Cabbage {Cabbage}");
        }

        public async Task ChangeSates(ref StateEntitiesEnum element, StateEntitiesEnum state)
        {
            await Thread.Sleep(1000);
            Console.WriteLine($"Wolf {Wolf} & Goat = {Goat} & Cabbage {Cabbage}");
            element = state;
        }

        public Task Execute()
        {
            List<Task> tasks = new List<Task>() { new Task(Wolf), new Task(Goat), new Task(Cabbage) };
            foreach (var elem in tasks) {
                elem.Start();
            }
            Task.WaitAll(tasks);
        }
    }
}