namespace Core.InvitationPhase
{
    using System;

    public class InvitationAccepted
    {
        public InvitationAccepted(Guid invitationToken)
        {
            this.InvitationToken = invitationToken;
        }

        public Guid InvitationToken { get; private set; }
    }
}