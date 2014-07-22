namespace Risk.Core
{
    using System;

    public class Territory
    {
        public int PlacedUnits { get; private set; }

        public Guid OccupyingPlayer { get; private set; }

        public void PlaceUnit(Guid playerId)
        {
            this.PlacedUnits = 1;
            this.OccupyingPlayer = playerId;
        }
    }
}