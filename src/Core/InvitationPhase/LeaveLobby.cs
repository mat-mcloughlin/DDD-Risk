namespace Core.InvitationPhase
{
    using System;

    public class LeaveLobby
    {
        public LeaveLobby(Guid playerId)
        {
            this.PlayerId = playerId;
        }

        public Guid PlayerId { get; private set; }
    }
}