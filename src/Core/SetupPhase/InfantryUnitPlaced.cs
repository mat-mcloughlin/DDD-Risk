namespace Core.SetupPhase
{
    using System;

    public class InfantryUnitPlaced
    {
        public InfantryUnitPlaced(Guid gameSetupId, Guid currentPlayerId, Guid nextPlayer, string territory)
        {
            GameSetupId = gameSetupId;
            CurrentPlayerId = currentPlayerId;
            Territory = territory;
            NextPlayer = nextPlayer;
        }

        public Guid CurrentPlayerId { get; private set; }

        public string Territory { get; private set; }

        public Guid NextPlayer { get; private set; }

        public Guid GameSetupId { get; private set; }
    }
}