namespace Core.InvitationPhase
{
    using System;

    public class Player
    {
        public Player(string name, Guid invitationToken)
        {
            Name = name;
            InvitationToken = invitationToken;
        }

        public string Name { get; private set; }

        public Guid InvitationToken { get; private set; }
    }
}