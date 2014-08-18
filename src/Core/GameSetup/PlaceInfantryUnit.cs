namespace Core.GameSetup
{
    public class PlaceInfantryUnit
    {
        public PlaceInfantryUnit(string territory)
        {
            this.Territory = territory;
        }

        public string Territory { get; private set; }
    }
}
