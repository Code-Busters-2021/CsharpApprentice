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
                    (entityOne == StateEntitiesEnum.RightBank && entityTwo == StateEntitiesEnum.RightBank) || 
                    (entityOne == StateEntitiesEnum.Boat && entityTwo == StateEntitiesEnum.Boat) && 
                    !(Wolf == StateEntitiesEnum.RightBank && Goat == StateEntitiesEnum.RightBank && Cabbage == StateEntitiesEnum.RightBank);
        }

        public bool IsFinish()
        {
            return Wolf == StateEntitiesEnum.RightBank && Goat == StateEntitiesEnum.RightBank && Cabbage == StateEntitiesEnum.RightBank;   
        }

        public async Task WolfFunc()
        {
            CrossRiver(ref Wolf);
            if (IsInTheSameState(Wolf, Goat))
                throw new Exception("The wolf ate the goat");
        }

        public async Task Goatfunc()
        {
            CrossRiver(ref Goat);
            if (IsInTheSameState(Goat, Cabbage))
                throw new Exception("The Goat ate the Cabbage");
        }

        public async void Cabbagefunc()
        {
            CrossRiver(ref Cabbage);
        }

        public Task CrossRiver(ref StateEntitiesEnum element)
        {
            StateEntitiesEnum tmpElem = element;
            element = StateEntitiesEnum.Boat;
            await Thread.Sleep(1000);
            element = tmpElem == StateEntitiesEnum.LeftBank ? StateEntitiesEnum.RightBank : StateEntitiesEnum.LeftBank;
            Console.WriteLine($"Wolf {Wolf} & Goat = {Goat} & Cabbage {Cabbage}");
        }
        public Task Execute()
        {
            Goat();
            Wolf();
            Goat();
            Cabbage();
            Goat();
        }
    }
}