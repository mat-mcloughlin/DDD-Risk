namespace Risk.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Xbehave;

    using Xunit;
    using Xunit.Should;

    public class StarterForTen
    {
        [Scenario]
        public void Creating_a_new_game(string gameName, PreGame preGame)
        {
            "Given a game name"
                .Given(() => gameName = "Test");

            "When I create a new game"
                .When(() => preGame = new PreGame(gameName));

            "A game created with a name"
                .Then(() => preGame.GameName.ShouldBe(gameName));
        }

        [Scenario]
        public void Inviting_player_to_game(string playerName, Guid invitationToken, PreGame preGame)
        {
            "Given a game"
                .Given(() => preGame = new PreGame("Test"));

            "And a player name".And(
                () => playerName = "Bryan");

            "And a invitation token".And(
                () => invitationToken = new Guid("7d9b4a47-b0e3-4aa3-965a-631b5a535de5"));

            "When I invite the player"
                .When(() => preGame.InvitePlayer(playerName, invitationToken));

            "A user invited event is raised"
                .Then(() => preGame.InvitedPlayers.ShouldContain(new KeyValuePair<Guid, string>(invitationToken, playerName)));
        }

        [Scenario]
        public void Cannot_accept_invitation_as_not_invited(Guid playerId, string playerName, Guid invitationToken, PreGame preGame)
        {
            "Given a game"
                .Given(() => preGame = new PreGame("Test"));

            "And a player id".And(
                () => playerId = new Guid("7d9b4a47-b0e3-4aa3-965a-631b5a535de5"));

            "And a player name".And(
                () => playerName = "Bryan");

            "And an invalid token"
                .And(() => invitationToken = Guid.NewGuid());

            "Then throws an error when trying to accept invitation"
                .Then(() => Assert.Throws<InvalidInvitationToken>(() => preGame.AcceptInvitation(playerId, playerName, invitationToken)));
        }

        [Scenario]
        public void Accepting_an_invitation_to_game(Guid playerId, string playerName, Guid invitationToken, PreGame preGame)
        {
            "Given a game"
                .Given(() => preGame = new PreGame("Test"));

            "With an invited player"
                .And(() =>
                    {
                        playerName = "Bryan";
                        invitationToken = new Guid("7d9b4a47-b0e3-4aa3-965a-631b5a535de5");
                        preGame.InvitePlayer(playerName, invitationToken);
                    });

            "When they accept the invitation with a valid token"
                .When(() =>
                    {
                        playerId = new Guid("7d9b4a47-b0e3-4aa3-965a-631b5a535de5");
                        preGame.AcceptInvitation(playerId, playerName, invitationToken);
                    });

            "The invitation accepted event is raised"
                .Then(() => preGame.JoinedPlayers.ShouldContain(new KeyValuePair<Guid, string>(playerId, playerName)));
        }

        [Scenario]
        public void When_too_many_people_accept_the_invitation_then_an_exception_is_thrown(string playerName, IList<Guid> invitationTokens, IList<Guid> playerIds, PreGame preGame)
        {
            "Given the a game"
                .Given(() => preGame = new PreGame("Test"));

            "And 10 invitations"
                .And(() =>
                    {
                        invitationTokens = new List<Guid>();
                        for (var x = 0; x <= 10; x++)
                        {
                            var invitationToken = Guid.NewGuid();
                            invitationTokens.Add(invitationToken);
                            preGame.InvitePlayer("Bryan", invitationToken);
                        }
                    });

            "When I invite 6 players"
                .When(() =>
                    {
                        playerIds = new List<Guid>();
                        for (var x = 0; x < 6; x++)
                        {
                            var invitationToken = invitationTokens[x];
                            var playerId = Guid.NewGuid();
                            playerIds.Add(playerId);
                            preGame.AcceptInvitation(playerId, playerName, invitationToken);
                        }
                    });

            "Then I invite one more player an exception is thrown"
                .Then(() => Assert.Throws<TooManyPlayersException>(() =>
                    {
                        var playerId = playerIds.First();
                        preGame.AcceptInvitation(playerId, playerName, invitationTokens[6]);
                    }));
        }

        [Scenario]
        public void User_leaving_pregame(Guid playerId, string playerName, Guid invitationToken, PreGame preGame)
        {
            "Given a game"
                .Given(() => preGame = new PreGame("Test"));

            "With a player"
                .And(() =>
                    {
                        playerId = new Guid("7d9b4a47-b0e3-4aa3-965a-631b5a535de5");
                        playerName = "Bryan";
                        invitationToken = new Guid("7d9b4a47-b0e3-4aa3-965a-631b5a535de5");
                        preGame.InvitePlayer(playerName, invitationToken);
                        preGame.AcceptInvitation(playerId, playerName, invitationToken);
                    });

            "When the player leaves the game"
                .And(() => preGame.LeaveGame(playerId));

            "A player left event is raised"
                .Then(() => preGame.JoinedPlayers.ShouldNotContain(new KeyValuePair<Guid, string>(playerId, playerName)));
        }
    }

    public class PreGame
    {
        private const int MaxNumberOfPlayers = 6;

        public PreGame(string gameName)
            : this()
        {
            this.GameName = gameName;
        }

        private PreGame()
        {
            this.InvitedPlayers = new Dictionary<Guid, string>();
            this.JoinedPlayers = new Dictionary<Guid, string>();
        }

        public string GameName { get; private set; }

        public IDictionary<Guid, string> InvitedPlayers { get; private set; }

        public IDictionary<Guid, string> JoinedPlayers { get; private set; }

        public void InvitePlayer(string playerName, Guid invitationToken)
        {
            this.InvitedPlayers.Add(invitationToken, playerName);
        }

        public void AcceptInvitation(Guid playerId, string playerName, Guid invitationToken)
        {
            this.CheckMaxNumberOfPlayersHasntBeenExceded();

            this.CheckInvitationTokenIsValid(invitationToken);

            this.JoinedPlayers.Add(playerId, playerName);
        }

        public void LeaveGame(Guid playerId)
        {
            this.JoinedPlayers.Remove(playerId);
        }

        private void CheckInvitationTokenIsValid(Guid invitationToken)
        {
            if (!this.InvitedPlayers.ContainsKey(invitationToken))
            {
                throw new InvalidInvitationToken();
            }
        }

        private void CheckMaxNumberOfPlayersHasntBeenExceded()
        {
            if (this.JoinedPlayers.Count >= MaxNumberOfPlayers)
            {
                throw new TooManyPlayersException();
            }
        }
    }

    public class InvalidInvitationToken : Exception
    {
    }

    public class TooManyPlayersException : Exception
    {
    }
}