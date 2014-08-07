namespace Core.GameCreation
{
    using System;

    public class InvitePlayer
    {
        public InvitePlayer(Guid playerId, string playerName, Guid invitationToken)
        {
            this.PlayerId = playerId;
            this.PlayerName = playerName;
            this.InvitationToken = invitationToken;
        }

        public Guid PlayerId { get; private set; }

        public string PlayerName { get; private set; }

        public Guid InvitationToken { get; private set; }
    }
}