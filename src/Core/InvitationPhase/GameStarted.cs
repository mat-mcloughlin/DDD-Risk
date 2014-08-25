namespace Core.InvitationPhase
{
    using System;
    using System.Collections.Generic;

    public class GameStarted
    {
        public GameStarted(Guid gameId, string gameName, List<Guid> joinedPlayers)
        {
           GameId = gameId;
           GameName = gameName;
           JoinedPlayers = joinedPlayers;
        }

        public Guid GameId { get; set; }

        public string GameName { get; set; }

        public List<Guid> JoinedPlayers { get; private set; }
    }
}