namespace Core.GameSetup
{
    public class StateOfTheTerritory
    {
        public StateOfTheTerritory(string territoryName)
        {
            this.TerritoryName = territoryName;
        }

        public string TerritoryName { get; private set; }
    }
}