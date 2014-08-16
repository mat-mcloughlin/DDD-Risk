namespace Core.InvitationPhase
{
    using System;

    public class LeftLobby
    {
        public LeftLobby(Guid playerId)
        {
            this.PlayerId = playerId;
        }

        public Guid PlayerId { get; private set; }
    }
}