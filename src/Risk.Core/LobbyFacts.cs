namespace Risk.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Xbehave;

    using Xunit;
    using Xunit.Should;

    public class LobbyFacts
    {
        [Scenario]
        public void Creating_a_new_game(string gameName, Lobby lobby)
        {
            "Given a game name"
                .Given(() => gameName = "Test");

            "When I create a new game"
                .When(() => lobby = new Lobby(gameName));

            "A game is created with a name"
                .Then(() => lobby.GameName.ShouldBe(gameName));
        }

        [Scenario]
        public void Inviting_player_to_game(string playerName, Guid invitationToken, Lobby lobby)
        {
            "Given a game"
                .Given(() => lobby = new Lobby("Test"));

            "And a player name".And(
                () => playerName = "Bryan");

            "And a invitation token".And(
                () => invitationToken = new Guid("7d9b4a47-b0e3-4aa3-965a-631b5a535de5"));

            "When I invite the player"
                .When(() => lobby.InvitePlayer(playerName, invitationToken));

            "A user is added to the invited players"
                .Then(() => lobby.InvitedPlayers.ShouldContain(new KeyValuePair<Guid, string>(invitationToken, playerName)));
        }

        [Scenario]
        public void Cannot_accept_invitation_as_not_invited(Guid playerId, string playerName, Guid invitationToken, Lobby lobby)
        {
            "Given a game"
                .Given(() => lobby = new Lobby("Test"));

            "And a player id".And(
                () => playerId = new Guid("7d9b4a47-b0e3-4aa3-965a-631b5a535de5"));

            "And a player name".And(
                () => playerName = "Bryan");

            "And an invalid token"
                .And(() => invitationToken = Guid.NewGuid());

            "Then an error is thrown when trying to accept an invitation"
                .Then(() => Assert.Throws<InvalidInvitationToken>(() => lobby.AcceptInvitation(playerId, playerName, invitationToken)));
        }

        [Scenario]
        public void Accepting_an_invitation_to_game(Guid playerId, string playerName, Guid invitationToken, Lobby lobby)
        {
            "Given a game"
                .Given(() => lobby = new Lobby("Test"));

            "With an invited player"
                .And(() =>
                    {
                        playerName = "Bryan";
                        invitationToken = new Guid("7d9b4a47-b0e3-4aa3-965a-631b5a535de5");
                        lobby.InvitePlayer(playerName, invitationToken);
                    });

            "When they accept the invitation with a valid token"
                .When(() =>
                    {
                        playerId = new Guid("7d9b4a47-b0e3-4aa3-965a-631b5a535de5");
                        lobby.AcceptInvitation(playerId, playerName, invitationToken);
                    });

            "The player is added to the joined players"
                .Then(() => lobby.JoinedPlayers.ShouldContain(new KeyValuePair<Guid, string>(playerId, playerName)));
        }

        [Scenario]
        public void When_too_many_people_accept_the_invitation_then_an_exception_is_thrown(string playerName, IList<Guid> invitationTokens, IList<Guid> playerIds, Lobby lobby)
        {
            "Given the a game"
                .Given(() => lobby = new Lobby("Test"));

            "And 10 invitations"
                .And(() =>
                    {
                        invitationTokens = new List<Guid>();
                        for (var x = 0; x <= 10; x++)
                        {
                            var invitationToken = Guid.NewGuid();
                            invitationTokens.Add(invitationToken);
                            lobby.InvitePlayer("Bryan", invitationToken);
                        }
                    });

            "When I invite 6 players"
                .When(() =>
                    {
                        playerIds = new List<Guid>();
                        for (var x = 1; x <= 6; x++)
                        {
                            var invitationToken = invitationTokens[x];
                            var playerId = Guid.NewGuid();
                            playerIds.Add(playerId);
                            lobby.AcceptInvitation(playerId, playerName, invitationToken);
                        }
                    });

            "Then I invite one more player an exception is thrown"
                .Then(() => Assert.Throws<TooManyPlayersException>(() =>
                    {
                        var playerId = playerIds.First();
                        lobby.AcceptInvitation(playerId, playerName, invitationTokens[6]);
                    }));
        }

        [Scenario]
        public void User_leaving_pregame(Guid playerId, string playerName, Guid invitationToken, Lobby lobby)
        {
            "Given a game"
                .Given(() => lobby = new Lobby("Test"));

            "With a player"
                .And(() =>
                    {
                        playerId = new Guid("7d9b4a47-b0e3-4aa3-965a-631b5a535de5");
                        playerName = "Bryan";
                        invitationToken = new Guid("7d9b4a47-b0e3-4aa3-965a-631b5a535de5");
                        lobby.InvitePlayer(playerName, invitationToken);
                        lobby.AcceptInvitation(playerId, playerName, invitationToken);
                    });

            "When the player leaves the game"
                .And(() => lobby.LeaveGame(playerId));

            "Then the player is removed from the joined players"
                .Then(() => lobby.JoinedPlayers.ShouldNotContain(new KeyValuePair<Guid, string>(playerId, playerName)));
        }

        [Scenario]
        [Example(0)]
        [Example(1)]
        public void Starting_a_game_with_not_enough_players_throws_exception(int numberOfPlayers, Lobby lobby)
        {
            "Given a game"
                .Given(() => lobby = new Lobby("Test"));

            "With a number of invited and accepted players"
                .And(() =>
                {
                    for (var x = 1; x <= numberOfPlayers; x++)
                    {
                        var invitationToken = Guid.NewGuid();
                        lobby.InvitePlayer("Bryan", invitationToken);
                        lobby.AcceptInvitation(Guid.NewGuid(), "Bryan", invitationToken);
                    }
                });

            "Then an exception is thrown when trying to start the game"
                .Then(() => Assert.Throws<NotEnoughPlayersException>(() => lobby.StartGame()));
        }
    }
}