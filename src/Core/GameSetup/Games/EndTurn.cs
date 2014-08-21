namespace Core.GameSetup.Games
{
    using System;

    public class EndTurn
    {
        public EndTurn(Guid turnToken, Board board)
        {
            this.TurnToken = turnToken;
            this.Board = board;
        }

        public Guid TurnToken { get; private set; }

        public Board Board { get; private set; }
    }
}