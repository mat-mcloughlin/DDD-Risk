namespace Core.SetupPhase.Projections
{
    using Core.Infrastructure;
    using Core.SetupPhase;
    using Core.SetupPhase.DTO;

    using Raven.Client;

    public class GameSetupStartedProjection : IObserve<GameSetupStarted>
    {
        private readonly IDocumentSession _session;

        public GameSetupStartedProjection(IDocumentSession session)
        {
            this._session = session;
        }

        public void Observe(GameSetupStarted e)
        {
            var boardStateDTO = new BoardStateDTO { Id = e.GameSetupId };

            foreach (var territory in e.Board.Territories)
            {
                boardStateDTO.Territories.Add(new TerritoryDTO { Name = territory.Key });
            }

            this._session.Store(boardStateDTO);
            this._session.SaveChanges();
        }
    }
}
