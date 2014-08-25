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

        public void Handle(LeaveLobby command)
        {
            var lobby = _repository.GetById<Lobby>(command.LobbyId);
            lobby.LeaveLobby(command.PlayerId);
            _repository.Save(lobby, Guid.NewGuid());
        }
    }
}
