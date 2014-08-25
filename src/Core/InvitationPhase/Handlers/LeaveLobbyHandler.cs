namespace Core.InvitationPhase.Handlers
{
    using System;

    using CommonDomain.Persistence;

    using Core.Infrastructure;

    public class LeaveLobbyHandler : ICommandHandler<LeaveLobby>
    {
        private readonly IRepository _repository;

        public LeaveLobbyHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(LeaveLobby c)
        {
            var lobby = _repository.GetById<Lobby>(c.LobbyId);
            lobby.LeaveLobby(c.PlayerId);
            _repository.Save(lobby, Guid.NewGuid());
        }
    }
}
