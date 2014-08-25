namespace Core.GameSetup.Games
{
    using System;

    public class InfantryUnitPlaced
    {
        public InfantryUnitPlaced(Guid currentPlayerId, Guid nextPlayer, string territory)
        {
            this.CurrentPlayerId = currentPlayerId;
            Territory = territory;
            NextPlayer = nextPlayer;
        }

        public Guid CurrentPlayerId { get; private set; }

        public string Territory { get; private set; }

        public Guid NextPlayer { get; private set; }
    }
}