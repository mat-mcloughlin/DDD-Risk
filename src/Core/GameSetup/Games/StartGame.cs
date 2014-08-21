namespace Core.GameSetup.Games
{
    using System;
    using System.Collections.Generic;

    public class StartGame
    {
        public StartGame(Guid gameId, string gameName, Dictionary<Guid, string> players)
        {
            this.Players = players;
            this.GameId = gameId;
            this.GameName = gameName;
        }

        public Dictionary<Guid, string> Players { get; private set; }

        public Guid GameId { get; private set; }

        public string GameName { get; private set; }
    }
}