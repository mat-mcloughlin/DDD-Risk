namespace Core.Workflows
{
    using System;

    using Core.Infrastructure;
    using Core.SetupPhase;

    using GameStarted = Core.InvitationPhase.GameStarted;

    public class GameSetupStartedWorkflow : IObserve<GameStarted>
    {
        private readonly CommandDispatcher _dispatcher;

        public GameSetupStartedWorkflow(CommandDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void Observe(GameStarted e)
        {
            var command = new StartGameSetup(e.SetupGameId, e.GameId, e.GameName, e.Players);
            _dispatcher.Dispatch(command);
        }
    }
}
