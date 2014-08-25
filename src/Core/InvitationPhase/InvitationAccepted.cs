namespace Core.InvitationPhase
{
    using System;

    public class InvitationAccepted
    {
        public InvitationAccepted(Guid invitationToken)
        {
            InvitationToken = invitationToken;
        }

        public Guid InvitationToken { get; private set; }
    }
}