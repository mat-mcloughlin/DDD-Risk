namespace Core.InvitationPhase
{
    using System;

    public class Player
    {
        public Player(Guid id, string name)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; private set; }

        public Guid Id { get; private set; }
    }
}