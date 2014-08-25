namespace Core.SetupPhase
{
    using System;
    using System.Collections.Generic;

    public class GameSetupStarted
    {
        public GameSetupStarted(Guid gameSetupId, Guid gameId, IList<Guid> players, Guid startingPlayerId, Board board, int numberOfStartingInfantryUnits)
        {
            this.GameId = gameId;
            this.GameSetupId = gameSetupId;
            this.Players = players;
            this.StartingPlayerId = startingPlayerId;
            this.Board = board;
            this.NumberOfStartingInfantryUnits = numberOfStartingInfantryUnits;
        }

        public Guid GameId { get; private set; }

        public Guid GameSetupId { get; private set; }

        public IList<Guid> Players { get; private set; }

        public Guid StartingPlayerId { get; private set; }

        public Board Board { get; private set; }

        public int NumberOfStartingInfantryUnits { get; private set; }
    }
}