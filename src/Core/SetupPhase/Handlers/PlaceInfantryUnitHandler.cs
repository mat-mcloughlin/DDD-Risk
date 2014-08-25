namespace Core.SetupPhase.Handlers
{
    using System;

    using CommonDomain.Persistence;

    using Core.Infrastructure;

    public class PlaceInfantryUnitHandler : ICommandHandler<PlaceInfantryUnit>
    {
        private readonly IRepository _repository;

        public PlaceInfantryUnitHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(PlaceInfantryUnit c)
        {
            var gameSetup = _repository.GetById<GameSetup>(c.GameSetupId);
            gameSetup.PlaceInfantryUnit(c.PlayerId, c.Territory);
            
            _repository.Save(gameSetup, Guid.NewGuid());
        }
    }
}
