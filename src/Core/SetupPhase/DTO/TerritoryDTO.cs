namespace Core.SetupPhase.DTO
{
    using System;

    public class TerritoryDTO
    {
        public int NumberOfInfantryUnits { get; set; }

        public Guid? OccupyingPlayerId { get; set; }

        public string Name { get; set; }
    }
}