namespace Core.InvitationPhase
{
    using System;

    public class PlayerInvited
    {
        public PlayerInvited(Guid playerId, string playerName, Guid invitationToken)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            InvitationToken = invitationToken;
        }

        public Guid PlayerId { get; private set; }

        public string PlayerName { get; private set; }

        public Guid InvitationToken { get; private set; }
    }
}