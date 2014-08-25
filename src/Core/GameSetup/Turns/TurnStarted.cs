namespace Core.GameSetup.Turns
{
    using System;

    public class TurnStarted
    {
        public TurnStarted(Guid turnId, Guid playerId, Board board)
        {
            this.TurnId = turnId;
            this.PlayerId = playerId;
            this.Board = board;
        }

        public Guid PlayerId { get; private set; }

        public Board Board { get; set; }

        public Guid TurnId { get; private set; }
    }
}