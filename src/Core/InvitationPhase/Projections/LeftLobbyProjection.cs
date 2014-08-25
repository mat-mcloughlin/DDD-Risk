namespace Core.InvitationPhase.Projections
{
    using System.Linq;

    using Core.Infrastructure;
    using Core.InvitationPhase.DTO;

    using Raven.Client;

    public class LeftLobbyProjection : IObserve<LeftLobby>
    {
        private readonly IDocumentSession _session;

        public LeftLobbyProjection(IDocumentSession session)
        {
            _session = session;
        }

        public void Observe(LeftLobby e)
        {
            var lobbyDTO = _session.Load<LobbyDTO>(e.LobbyId);
            var playerToRemove = lobbyDTO.Players.SingleOrDefault(p => p.Id == e.PlayerId);

            if (playerToRemove != null)
            {
                lobbyDTO.Players.Remove(playerToRemove);
            }

            _session.SaveChanges();
        }
    }
}
