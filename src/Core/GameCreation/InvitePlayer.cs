namespace Core.GameCreation
{
    using System;

    public class InvitePlayer
    {
        public InvitePlayer(Guid playerId, string playerName)
        {
            this.PlayerId = playerId;
            this.PlayerName = playerName;
        }

        public Guid PlayerId { get; private set; }

        public string PlayerName { get; private set; }
    }
}