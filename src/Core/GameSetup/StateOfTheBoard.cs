namespace Core.GameSetup
{
    using System.Collections.Generic;

    public class StateOfTheBoard
    {
        public StateOfTheBoard(IList<StateOfTheTerritory> territories)
        {
            this.Territories = territories;
        }

        public IList<StateOfTheTerritory> Territories { get; private set; }
    }
}