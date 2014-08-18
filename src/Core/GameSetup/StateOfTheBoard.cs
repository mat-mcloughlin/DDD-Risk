namespace Core.GameSetup
{
    using System.Collections.Generic;

    public class StateOfTheBoard
    {
        public StateOfTheBoard(IDictionary<string, StateOfTheTerritory> territories)
        {
            this.Territories = territories;
        }

        public IDictionary<string, StateOfTheTerritory> Territories { get; private set; }
    }
}