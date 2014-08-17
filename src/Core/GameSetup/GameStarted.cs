namespace Core.GameSetup
{
    using System;
    using System.Collections.Generic;

    public class GameStarted
    {
        public GameStarted(Guid gameId, string gameName, IDictionary<Guid, string> players)
        {
            this.GameId = gameId;
            this.GameName = gameName;
            this.Players = players;
        }

        public Guid GameId { get; private set; }

        public string GameName { get; private set; }

        public IDictionary<Guid, string> Players { get; private set; }
    }
}