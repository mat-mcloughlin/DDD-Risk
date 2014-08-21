namespace Core.GameSetup.Games
{
    using System;
    using System.Collections.Generic;

    public class GameStarted
    {
        public GameStarted(Guid gameId, string gameName, IDictionary<Guid, string> players, Guid startingPlayer, Board board, int numberOfStartingInfantryUnits, Guid turnToken)
        {
            this.GameId = gameId;
            this.GameName = gameName;
            this.Players = players;
            this.StartingPlayer = startingPlayer;
            this.Board = board;
            this.NumberOfStartingInfantryUnits = numberOfStartingInfantryUnits;
            this.TurnToken = turnToken;
        }

        public Guid GameId { get; private set; }

        public string GameName { get; private set; }

        public IDictionary<Guid, string> Players { get; private set; }

        public Guid StartingPlayer { get; private set; }

        public Board Board { get; private set; }

        public int NumberOfStartingInfantryUnits { get; private set; }

        public Guid TurnToken { get; private set; }
    }
}