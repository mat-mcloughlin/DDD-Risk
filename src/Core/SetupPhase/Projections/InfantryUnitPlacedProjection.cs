namespace Core.InvitationPhase.Projections
{
    using System.Linq;

    using Core.Infrastructure;
    using Core.SetupPhase;
    using Core.SetupPhase.DTO;

    using Raven.Client;

    public class InfantryUnitPlacedProjection : IObserve<InfantryUnitPlaced>
    {
        private readonly IDocumentSession _session;

        public InfantryUnitPlacedProjection(IDocumentSession session)
        {
            _session = session;
        }

        public void Observe(InfantryUnitPlaced e)
        {
            var boardStateDTO = _session.Load<BoardStateDTO>(e.GameSetupId);

            var territory = boardStateDTO.Territories.FirstOrDefault(t => t.Name == e.Territory);

            if (territory != null)
            {
                territory.OccupyingPlayerId = e.CurrentPlayerId;
                territory.NumberOfInfantryUnits++;
            }

            _session.SaveChanges();
        }
    }
}
