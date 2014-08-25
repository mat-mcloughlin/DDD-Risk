namespace Core.InvitationPhase
{
    using System;

    public class LeaveLobby
    {
        public LeaveLobby(Guid lobbyId, Guid playerId)
        {
            LobbyId = lobbyId;
            PlayerId = playerId;
        }

        public Guid LobbyId { get; set; }

        public Guid PlayerId { get; private set; }
    }
}