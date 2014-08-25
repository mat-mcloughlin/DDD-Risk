namespace Core.InvitationPhase.Handlers
{
    using System;

    using CommonDomain.Persistence;

    using Core.Infrastructure;

    public class AcceptInvitationHandler : ICommandHandler<AcceptInvitation>
    {
        private readonly IRepository _repository;

        public AcceptInvitationHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(AcceptInvitation command)
        {
            var lobby = _repository.GetById<Lobby>(command.LobbyId);
            lobby.AcceptInvitation(command.InvitationToken);
            _repository.Save(lobby, Guid.NewGuid());
        }
    }
}
