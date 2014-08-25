namespace Core.InvitationPhase
{
    using System;

    public class InvitationAccepted
    {
        public InvitationAccepted(Guid lobbyId, Guid playerId, string playerName, Guid invitationToken)
        {
            LobbyId = lobbyId;
            PlayerId = playerId;
            PlayerName = playerName;
            InvitationToken = invitationToken;
        }

        public Guid InvitationToken { get; private set; }

        public Guid LobbyId { get; private set; }

        public Guid PlayerId { get; set; }

        public string PlayerName { get; set; }
    }
}