namespace Core.InvitationPhase.Projections
{
    using Core.Infrastructure;
    using Core.InvitationPhase.DTO;

    using Raven.Client;

    public class InvitationAcceptedProjection : IObserve<InvitationAccepted>
    {
        private readonly IDocumentSession _session;

        public InvitationAcceptedProjection(IDocumentSession session)
        {
            this._session = session;
        }

        public void Observe(InvitationAccepted e)
        {
            var lobbyDTO = _session.Load<LobbyDTO>(e.LobbyId);
            lobbyDTO.Players.Add(new PlayerDTO { Id = e.PlayerId, Name = e.PlayerName });
            _session.SaveChanges();
        }
    }
}
