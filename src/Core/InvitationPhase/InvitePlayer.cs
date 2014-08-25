namespace Core.InvitationPhase
{
    using System;

    public class InvitePlayer
    {
        public InvitePlayer(Guid lobbyId, Guid playerId, string playerName, Guid invitationToken)
        {
            LobbyId = lobbyId;
            PlayerId = playerId;
            PlayerName = playerName;
            InvitationToken = invitationToken;
        }

        public Guid LobbyId { get; private set; }

        public Guid PlayerId { get; private set; }

        public string PlayerName { get; private set; }

        public Guid InvitationToken { get; private set; }
    }
}