namespace Core.InvitationPhase
{
    using System;

    public class AcceptInvitation
    {
        public AcceptInvitation(Guid lobbyId, Guid invitationToken)
        {
            LobbyId = lobbyId;
            InvitationToken = invitationToken;
        }

        public Guid LobbyId { get; private set; }

        public Guid InvitationToken { get; private set; }
    }
}