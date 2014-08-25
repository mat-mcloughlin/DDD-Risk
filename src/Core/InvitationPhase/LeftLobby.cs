namespace Core.InvitationPhase
{
    using System;

    public class LeftLobby
    {
        public LeftLobby(Guid lobbyId, Guid playerId)
        {
            LobbyId = lobbyId;
            PlayerId = playerId;
        }

        public Guid LobbyId { get; private set; }

        public Guid PlayerId { get; private set; }
    }
}