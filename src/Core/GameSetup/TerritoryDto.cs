namespace Core.GameSetup
{
    using System;

    public class TerritoryDto
    {
        public TerritoryDto(int numberOfInfantry, Guid? occupyingPlayerId)
        {
            this.NumberOfInfantry = numberOfInfantry;
            this.OccupyingPlayerId = occupyingPlayerId;
        }

        public int NumberOfInfantry { get; private set; }

        public Guid? OccupyingPlayerId { get; private set; }
    }
}