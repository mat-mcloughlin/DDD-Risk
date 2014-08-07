namespace Core.Facts.GameCreation
{
    using System;
    using System.Linq;

    using Core.GameCreation;

    using Xbehave;

    using Xunit.Should;

    public class LobbyFacts
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
                        lobby.GameName.ShouldBe(gameName);
                        lobby.Host.Id.ShouldBe(hostId);
                        lobby.Host.Name.ShouldBe(hostName);
                    });
        }

        [Scenario]
        [Example("Mat")]
        [Example("Bryan")]
        public void Host_can_invite_player_to_lobby(string playerName, Guid playerId, Lobby lobby)
        {
            "Given a lobby"
                .Given(() => lobby = new Lobby(new CreateLobby("gameName", Guid.NewGuid(), "hostName")));

            "When we invite a player".When(
                () =>
                    {
                        playerId = new Guid("8e17de3f-7833-47a6-8f92-cf220cf953e2");
                        var command = new InvitePlayer(playerId, playerName);
                        lobby.Handle(command);
                    });

            "A player should be invited to the list of invited players".Then(
                () =>
                    {
                        lobby.InvitedPlayers.Count.ShouldBe(1);
                        var player = lobby.InvitedPlayers.Last();
                        player.Key.ShouldBe(playerId);
                        player.Value.Name.ShouldBe(playerName);
                    });
        }
    }
}
