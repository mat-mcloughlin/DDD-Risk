namespace Core.GameSetup.Turns
{
    using System;

    public class TurnStarted
    {
        public TurnStarted(Guid turnId, Guid playerId, BoardDto board)
        {
            this.TurnId = turnId;
            this.PlayerId = playerId;
            this.Board = board;
        }

        public Guid PlayerId { get; private set; }

        public BoardDto Board { get; set; }

        public Guid TurnId { get; private set; }
    }
}