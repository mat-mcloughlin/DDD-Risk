namespace Core.InvitationPhase
{
    using System;

    public class Player
    {
        public Player(string name, Guid invitationToken)
        {
            this.Name = name;
            this.InvitationToken = invitationToken;
        }

        public string Name { get; private set; }

        public Guid InvitationToken { get; private set; }
    }
}