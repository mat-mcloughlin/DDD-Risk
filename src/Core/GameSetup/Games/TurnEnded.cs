namespace Core.GameSetup.Games
{
    using System;

    public class TurnEnded
    {
        public TurnEnded(Guid turnToken, Guid currentPlayer, Guid nextPlayer, Board board, int numberOfInfantryUnitsLeft)
        {
            this.TurnToken = turnToken;
            this.CurrentPlayer = currentPlayer;
            Board = board;
            NextPlayer = nextPlayer;
            NumberOfInfantryUnitsLeft = numberOfInfantryUnitsLeft;
        }

        public Guid TurnToken { get; private set; }

        public Guid CurrentPlayer { get; set; }

        public Board Board { get; private set; }

        public Guid NextPlayer { get; private set; }

        public int NumberOfInfantryUnitsLeft { get; private set; }
    }
}