namespace Core.Facts.InvitationPhase
{
    using System;
    using System.Linq;

    using Core.InvitationPhase;

    using Xbehave;

    using Xunit.Should;

    public class LobbyCreation
    {
        [Scenario]
        [Example("gameOne", "Mat")]
        [Example("gameTwo", "Bryan")]
        public void Host_can_create_a_new_lobby(string gameName, string hostName, Guid hostId, Lobby lobby)
        {
            "Given a game name"
                .Given(() => { });

            "And a host"
                .And(() => hostId = new Guid("8e17de3f-7833-47a6-8f92-cf220cf953e2"));

            "When we create a lobby"
                .When(() =>
                {
                    var command = new CreateLobby(gameName, hostId, hostName);
                    lobby = new Lobby(command);
                });

            "A lobby should be created with a game name and host"
                .Then(() =>
                    {
                        lobby.ShouldNotBeNull();
                        
                        var @event = (LobbyCreated)lobby.Events.Last();
                        @event.GameName.ShouldBe(gameName);
                        @event.HostId.ShouldBe(hostId);
                        @event.HostName.ShouldBe(hostName);
                    });
        }
    }
}