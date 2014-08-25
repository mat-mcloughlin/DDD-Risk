namespace Core.Facts.InvitationPhase
{
    using System;

    using Core.InvitationPhase;

    using Xbehave;

    using Xunit.Should;

    public class LobbyCreation
    {
        [Scenario]
        [Example("gameOne", "Mat")]
        [Example("gameTwo", "Bryan")]
        void Host_can_create_a_new_lobby(string gameName, string hostName, Guid hostId, Guid lobbyId, Guid gameId, Lobby lobby)
        {
            "Given a game name, id and host id"
                .Given(() => { });

            "And a lobby id"
               .And(() => lobbyId = new Guid("8e17de3f-7833-47a6-8f92-cf220cf953e2"));

            "And a game id"
               .And(() => gameId = new Guid("8e17de3f-7833-47a6-8f92-cf220cf953e2"));

            "And a host"
                .And(() => hostId = new Guid("8e17de3f-7833-47a6-8f92-cf220cf953e2"));

            "When we create a lobby"
                .When(() =>
                    {
                        lobby = new Lobby(lobbyId, gameId, gameName, hostId, hostName);
                    });

            "A lobby should be created with a game name and host"
                .Then(() =>
                    {
                        lobby.ShouldNotBeNull();

                        var @event = lobby.LastEvent<LobbyCreated>();
                        @event.GameName.ShouldBe(gameName);
                        @event.GameId.ShouldBe(gameId);
                        @event.LobbyId.ShouldBe(lobbyId);
                        @event.HostId.ShouldBe(hostId);
                        @event.HostName.ShouldBe(hostName);
                    });
        }
    }
}