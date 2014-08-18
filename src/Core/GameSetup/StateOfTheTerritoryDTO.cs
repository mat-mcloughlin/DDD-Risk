namespace Core.GameSetup
{
    using System;

    public class StateOfTheTerritoryDto
    {
        public StateOfTheTerritoryDto(int numberOfOccupyingInfantryUnits, Guid? owningPlayerId)
        {
            this.NumberOfOccupyingInfantryUnits = numberOfOccupyingInfantryUnits;
            this.OwningPlayerId = owningPlayerId;
        }

        public int NumberOfOccupyingInfantryUnits { get; private set; }

        public Guid? OwningPlayerId { get; private set; }
    }
}