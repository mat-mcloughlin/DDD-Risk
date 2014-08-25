namespace Core.GameSetup.Games
{
    using System;

    public class EndTurn
    {
        public EndTurn(Guid turnId, Board board)
        {
            this.TurnId = turnId;
            this.Board = board;
        }

        public Guid TurnId { get; private set; }

        public Board Board { get; private set; }
    }
}