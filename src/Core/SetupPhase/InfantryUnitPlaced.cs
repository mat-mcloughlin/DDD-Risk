namespace Core.SetupPhase
{
    using System;

    public class InfantryUnitPlaced
    {
        public InfantryUnitPlaced(Guid gameSetupId, Guid currentPlayerId, Guid nextPlayerId, string territory)
        {
            GameSetupId = gameSetupId;
            CurrentPlayerId = currentPlayerId;
            Territory = territory;
            this.NextPlayerId = nextPlayerId;
        }

        public Guid CurrentPlayerId { get; private set; }

        public string Territory { get; private set; }

        public Guid NextPlayerId { get; private set; }

        public Guid GameSetupId { get; private set; }
    }
}