namespace Console
{
    using System;

    using Autofac;

    using Core.Infrastructure;
    using Core.InvitationPhase;

    using MemBus;

    class Program
    {
        static void Main(string[] args)
        {
            var container = AutofacSetup.Build();

            var dispatcher = container.Resolve<CommandDispatcher>();
            var bus = container.Resolve<IBus>();

            var lobbyId = Guid.NewGuid();
            var gameId = Guid.NewGuid();

            var createLobby = new CreateLobby(lobbyId, gameId, "Test Game", Guid.NewGuid(), "Mat");
            dispatcher.Dispatch(createLobby);

            var invitationToken = Guid.NewGuid();
            var invitePlayer = new InvitePlayer(lobbyId, Guid.NewGuid(), "Richard", invitationToken);
            dispatcher.Dispatch(invitePlayer);

            var acceptInvitation = new AcceptInvitation(lobbyId, invitationToken);
            dispatcher.Dispatch(acceptInvitation);

            var invitationToken2 = Guid.NewGuid();
            var invitePlayer2 = new InvitePlayer(lobbyId, Guid.NewGuid(), "Richard", invitationToken2);
            dispatcher.Dispatch(invitePlayer2);

            var acceptInvitation2 = new AcceptInvitation(lobbyId, invitationToken2);
            dispatcher.Dispatch(acceptInvitation2);

            var startGame = new StartGame(lobbyId);
            dispatcher.Dispatch(startGame);
        }
    }
}
