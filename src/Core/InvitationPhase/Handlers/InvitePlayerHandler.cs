namespace Core.InvitationPhase.Handlers
{
    using System;

    using CommonDomain.Persistence;

    using Core.Infrastructure;

    public class InvitePlayerHandler : ICommandHandler<InvitePlayer>
    {
        private readonly IRepository _repository;

        public InvitePlayerHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(InvitePlayer command)
        {
            var lobby = _repository.GetById<Lobby>(command.LobbyId);
            lobby.InvitePlayer(command.PlayerId, command.PlayerName, command.InvitationToken);
            _repository.Save(lobby, Guid.NewGuid());
        }
    }
}
