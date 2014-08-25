namespace Core.SetupPhase
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

        public int NumberOfInfantryUnits { get; set; }

        public Guid? OccupyingPlayerId { get; set; }
    }
}