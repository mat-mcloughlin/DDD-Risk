namespace Core.GameSetup.Turns
{
    using System;

    public class PlaceInfantryUnit
    {
        public PlaceInfantryUnit(Guid playerId, string territory)
        {
            PlayerId = playerId;
            Territory = territory;
        }

        public Guid PlayerId { get; private set; }

        public string Territory { get; private set; }
    }
}
