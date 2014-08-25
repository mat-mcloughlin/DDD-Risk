namespace Core.GameSetup.Games
{
    using System;
    using System.Collections.Generic;

    public class GameStarted
    {
        public GameStarted(Guid replaceMe, Guid gameId, IList<Guid> players, Guid startingPlayerId, Board board, int numberOfStartingInfantryUnits)
        {
            ReplaceMe = replaceMe;
            GameId = gameId;
            Players = players;
            StartingPlayerId = startingPlayerId;
            Board = board;
            NumberOfStartingInfantryUnits = numberOfStartingInfantryUnits;
        }

        public Guid ReplaceMe { get; private set; }

        public Guid GameId { get; private set; }

        public IList<Guid> Players { get; private set; }

        public Guid StartingPlayerId { get; private set; }

        public Board Board { get; private set; }

        public int NumberOfStartingInfantryUnits { get; private set; }
    }
}