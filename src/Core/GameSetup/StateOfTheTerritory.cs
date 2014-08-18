namespace Core.GameSetup
{
    using System;

    public class StateOfTheTerritory
    {
        internal StateOfTheTerritory(int numberOfInfantryUnits, Guid? occupyingPlayerId)
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