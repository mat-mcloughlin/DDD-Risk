namespace Console
{
    using System;

    using Autofac;

    using Core.Infrastructure;
    using Core.InvitationPhase;
    using Core.SetupPhase;

    using MemBus;

    class Program
    {
        static void Main(string[] args)
        {
            var container = AutofacSetup.Build();

            var dispatcher = container.Resolve<CommandDispatcher>();

            //var lobbyId = Guid.NewGuid();
            //var gameId = Guid.NewGuid();

            //var createLobby = new CreateLobby(lobbyId, gameId, "Test Game", Guid.NewGuid(), "Mat");
            //dispatcher.Dispatch(createLobby);

            //var invitationToken = Guid.NewGuid();
            //var playerId = Guid.NewGuid();
            //var invitePlayer = new InvitePlayer(lobbyId, playerId, "Richard", invitationToken);
            //dispatcher.Dispatch(invitePlayer);

            //var acceptInvitation = new AcceptInvitation(lobbyId, invitationToken);
            //dispatcher.Dispatch(acceptInvitation);

            ////var leaveLobby = new LeaveLobby(lobbyId, playerId);
            ////dispatcher.Dispatch(leaveLobby);

            //var invitationToken2 = Guid.NewGuid();
            //var invitePlayer2 = new InvitePlayer(lobbyId, Guid.NewGuid(), "Matt", invitationToken2);
            //dispatcher.Dispatch(invitePlayer2);

            //var acceptInvitation2 = new AcceptInvitation(lobbyId, invitationToken2);
            //dispatcher.Dispatch(acceptInvitation2);

            //var gameSetupId = Guid.NewGuid();
            //var startGame = new StartGame(lobbyId, gameSetupId);
            //dispatcher.Dispatch(startGame);

            var boardSetupId = new Guid("4c7e5f0fc0bf4d28a63ba9b0253bb9f1");
            var playerId = new Guid("59fbb53f-2c86-4b13-a6e5-740ffefdb2a7");

            var placeInfantryUnit = new PlaceInfantryUnit(boardSetupId, playerId, "Alaska");
            dispatcher.Dispatch(placeInfantryUnit);
        }
    }
}
