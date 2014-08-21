namespace Core.GameSetup.Turns
{
    using System;

    public class StartTurn
    {
        public StartTurn(Guid turnId, Guid playerId, BoardDto board)
        {
            this.TurnId = turnId;
            this.PlayerId = playerId;
            this.Board = board;
        }

        public Guid TurnId { get; private set; }

        public Guid PlayerId { get; private set; }

        public BoardDto Board { get; private set; }
    }
}