namespace Core.GameSetup
{
    using System;

    public class TurnStarted
    {
        public TurnStarted(Guid turnId, Guid playerId, StateOfTheBoardDto stateOfTheBoard)
        {
            this.TurnId = turnId;
            this.PlayerId = playerId;
            this.StateOfTheBoard = stateOfTheBoard;
        }

        public Guid PlayerId { get; private set; }

        public StateOfTheBoardDto StateOfTheBoard { get; set; }

        public Guid TurnId { get; private set; }
    }
}