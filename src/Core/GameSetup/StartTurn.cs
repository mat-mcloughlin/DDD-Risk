namespace Core.GameSetup
{
    using System;

    public class StartTurn
    {
        public StartTurn(Guid turnId, Guid playerId, StateOfTheBoardDto stateOfTheBoard)
        {
            this.TurnId = turnId;
            this.PlayerId = playerId;
            this.StateOfTheBoard = stateOfTheBoard;
        }

        public Guid TurnId { get; private set; }

        public Guid PlayerId { get; private set; }

        public StateOfTheBoardDto StateOfTheBoard { get; private set; }
    }
}