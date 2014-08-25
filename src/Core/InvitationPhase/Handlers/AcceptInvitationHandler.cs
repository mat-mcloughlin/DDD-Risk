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

        public void Handle(AcceptInvitation c)
        {
            var lobby = _repository.GetById<Lobby>(c.LobbyId);
            lobby.AcceptInvitation(c.InvitationToken);
            _repository.Save(lobby, Guid.NewGuid());
        }
    }
}
