namespace Core.InvitationPhase
{
    using System;
    using System.Collections.Generic;

    public class GameStarted
    {
        public GameStarted(Guid setupGameId, Guid gameId, string gameName, List<Guid> players)
        {
            SetupGameId = setupGameId;
            GameId = gameId;
            GameName = gameName;
            Players = players;
        }

        public Guid GameId { get; private set; }

        public string GameName { get; private set; }

        public List<Guid> Players { get; private set; }

        public Guid SetupGameId { get; private set; }
    }
}