namespace Core.InvitationPhase
{
    using System;

    public class LobbyCreated
    {
        public LobbyCreated(Guid lobbyId, Guid gameId, string gameName, Guid hostId, string hostName)
        {
            LobbyId = lobbyId;
            GameId = gameId;
            GameName = gameName;
            HostId = hostId;
            HostName = hostName;
        }

        public Guid LobbyId { get; private set; }

        public Guid GameId { get; set; }

        public string GameName { get; private set; }

        public Guid HostId { get; private set; }

        public string HostName { get; private set; }
    }
}