namespace Core.InvitationPhase
{
    using System;
    using System.Collections.Generic;

    public class GameStarted
    {
        public GameStarted(Guid gameId, string gameName, List<Guid> players)
        {
           GameId = gameId;
           GameName = gameName;
           Players = players;
        }

        public Guid GameId { get; set; }

        public string GameName { get; set; }

        public List<Guid> Players { get; private set; }
    }
}