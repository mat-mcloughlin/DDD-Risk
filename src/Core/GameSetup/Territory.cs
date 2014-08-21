namespace Core.GameSetup
{
    using System;

    public class Territory
    {
        public Territory()
            : this(0, null)
        {
        }

        public Territory(int numberOfInfantryUnits, Guid? occupyingPlayerId)
        {
            this.NumberOfInfantryUnits = numberOfInfantryUnits;
            this.OccupyingPlayerId = occupyingPlayerId;
        }

        public int NumberOfInfantryUnits { get; private set; }

        public Guid? OccupyingPlayerId { get; private set; }

        public void Occupy(Guid playerId)
        {
            this.NumberOfInfantryUnits++;
            this.OccupyingPlayerId = playerId;
        }
    }
}