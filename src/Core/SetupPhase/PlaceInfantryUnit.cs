namespace Core.SetupPhase
{
    using System;

    public class PlaceInfantryUnit
    {
        public PlaceInfantryUnit(Guid gameSetupId, Guid playerId, string territory)
        {
            this.GameSetupId = gameSetupId;
            this.PlayerId = playerId;
            this.Territory = territory;
        }

        public Guid GameSetupId { get; private set; }

        public Guid PlayerId { get; private set; }

        public string Territory { get; private set; }
    }
}