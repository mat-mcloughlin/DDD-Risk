namespace Core.InvitationPhase.Handlers
{
    using System;

    using CommonDomain.Persistence;

    using Core.Infrastructure;

    public class CreateLobbyHandler : ICommandHandler<CreateLobby>
    {
        private readonly IRepository _repository;

        public CreateLobbyHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(CreateLobby c)
        {
            var lobby = new Lobby(c.LobbyId, c.GameId, c.GameName, c.HostId, c.HostName);
            _repository.Save(lobby, Guid.NewGuid());
        }
    }
}
