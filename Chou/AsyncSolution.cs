namespace Chou
{
    class AsyncSolution
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
        public async Task ChangeSates(string entityName, StateEntitiesEnum state)
        {
            await Task.Delay(1000);
            Console.WriteLine($"Wolf {Wolf} & Goat = {Goat} & Cabbage {Cabbage}");
            switch (entityName) {
                case "Wolf":
                    Wolf = state;
                    break ;
                case "Goat":
                    Goat = state;
                    break ;
                case "Cabbage":
                    Cabbage = state;
                    break ;
                default:
                    throw new Exception($"Invalid parameter: {entityName} not in range Wolf Goat or Cabbage");
            }
            Console.WriteLine($"test switch : {entityName} & {state}");
        }

        public async Task Execute()
        {
            List<Task> tasks = new List<Task>() { new Task(WolfFunc), new Task(GoatFunc), new Task(CabbageFunc) };
            foreach (var elem in tasks) {
                elem.Start();
            }
            ChangeSates("Wolf", StateEntitiesEnum.Boat);
            ChangeSates("Goat", StateEntitiesEnum.Boat);
            ChangeSates("Cabbage", StateEntitiesEnum.Boat);
            Task.WaitAll(ChangeSates("Cabbage", StateEntitiesEnum.RightBank), ChangeSates("Wolf", StateEntitiesEnum.RightBank));
            await ChangeSates("Cabbage", StateEntitiesEnum.RightBank);
            Console.WriteLine("Finish async");
        }
    }
}