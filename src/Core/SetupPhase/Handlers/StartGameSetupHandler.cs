namespace Core.SetupPhase.Handlers
{
    using System;

    using CommonDomain.Persistence;

    using Core.Infrastructure;

    public class StartGameSetupHandler : ICommandHandler<StartGameSetup>
    {
        private readonly IRepository _repository;

        public StartGameSetupHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(StartGameSetup c)
        {
            var gameSetup = new GameSetup(c.GameSetupId, c.GameId, c.Players, new Dice());
            _repository.Save(gameSetup, Guid.NewGuid());
        }
    }
}
