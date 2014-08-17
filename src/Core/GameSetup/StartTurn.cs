namespace Core.GameSetup
{
    using System;

    public class StartTurn
    {
        public StartTurn(Guid playerId, string playerName, StateOfTheBoard stateOfTheBoard)
        {
            this.PlayerId = playerId;
            this.PlayerName = playerName;
            this.StateOfTheBoard = stateOfTheBoard;
        }

        public Guid PlayerId { get; private set; }

        public string PlayerName { get; private set; }

        public StateOfTheBoard StateOfTheBoard { get; private set; }
    }
}