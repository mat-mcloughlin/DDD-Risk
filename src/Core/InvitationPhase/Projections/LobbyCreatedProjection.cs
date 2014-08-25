namespace Core.InvitationPhase.Projections
{
    using Core.Infrastructure;
    using Core.InvitationPhase.DTO;

    using Raven.Client;

    public class LobbyCreatedProjection : IObserve<LobbyCreated>
    {
        private readonly IDocumentSession _session;

        public LobbyCreatedProjection(IDocumentSession session)
        {
            _session = session;
        }

        public void Observe(LobbyCreated e)
        {
            var lobbyDTO = new LobbyDTO
            {
                Id = e.LobbyId,
                GameId = e.GameId,
                GameName = e.GameName,
                HostId = e.HostId,
                HostName = e.HostName
            };

            _session.Store(lobbyDTO);
            _session.SaveChanges();
        }
    }
}
