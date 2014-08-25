namespace Core.GameSetup.Games
{
    using System;
    using System.Collections.Generic;

    public class StartGame
    {
        public StartGame(Guid gameId, string gameName, IList<Guid> players)
        {
            Players = players;
            GameId = gameId;
            GameName = gameName;
        }

        public IList<Guid> Players { get; private set; }

        public Guid GameId { get; private set; }

        public string GameName { get; private set; }
    }
}