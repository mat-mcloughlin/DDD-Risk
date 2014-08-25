namespace Core.Workflows
{
    using System;

    using Core.Infrastructure;
    using Core.InvitationPhase;

    public class GameSetupStartedWorkflow : IObserve<GameStarted>
    {
        private readonly CommandDispatcher _dispatcher;

        public GameSetupStartedWorkflow(CommandDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void Observe(GameStarted e)
        {
            var command = new GameSetup.Games.StartGame(e.GameId, e.GameName, e.JoinedPlayers);
            _dispatcher.Dispatch(command);
        }
    }
}
