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

        public void Handle(CreateLobby command)
        {
            var lobby = new Lobby(command.LobbyId, command.GameId, command.GameName, command.HostId, command.HostName);
            _repository.Save(lobby, Guid.NewGuid());
        }
    }
}
