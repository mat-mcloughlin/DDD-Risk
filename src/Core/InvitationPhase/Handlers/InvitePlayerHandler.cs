namespace Core.InvitationPhase.Handlers
{
    using System;

    using CommonDomain.Persistence;

    using Core.Infrastructure;

    // This should be validated to make sure its only the host can do it
    public class InvitePlayerHandler : ICommandHandler<InvitePlayer>
    {
        private readonly IRepository _repository;

        public InvitePlayerHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(InvitePlayer c)
        {
            var lobby = _repository.GetById<Lobby>(c.LobbyId);
            lobby.InvitePlayer(c.PlayerId, c.PlayerName, c.InvitationToken);
            _repository.Save(lobby, Guid.NewGuid());
        }
    }
}
