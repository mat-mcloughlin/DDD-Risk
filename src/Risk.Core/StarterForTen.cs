using Xbehave;
using System.Collections.Generic;
using System.Linq;
using Xunit.Should;

namespace Risk.Core
{
    using System;

    using Xunit;

    public class StarterForTen
    {
        [Scenario]
        public void creating_a_new_game(string gameName, PreGame preGame)
        {
            "Given a game name"
                .Given(() => gameName = "Test");

            "When I create a new game"
                .When(() => preGame = new PreGame(gameName));

            "A game created event is raised"
                .Then(() =>
                {
                    var @event = (GameCreated)preGame.Events.First();
                    @event.GameName.ShouldBe(gameName);
                });
        }

        [Scenario]
        public void inviting_player_to_game(string playerName, Guid invitationToken, PreGame preGame)
        {
            "Given a game"
                .Given(() => preGame = new PreGame("Test"));

            "And a player name".And(
                () => playerName = "Bryan");

            "And a invitation token".And(
                () => invitationToken = new Guid("7d9b4a47-b0e3-4aa3-965a-631b5a535de5"));

            "When I invite the player"
                .When(() => preGame.InvitePlayer(playerName, () => invitationToken));

            "A user invited event is raised"
                .Then(() =>
                {
                    var @event = (PlayerInvited)preGame.Events.Last();
                    @event.PlayerName.ShouldBe(playerName);
                    @event.InvitationToken.ShouldBe(invitationToken);
                });
        }

        [Scenario]
        public void cannot_accept_invitation_as_not_invited(string playerName, Guid invitationToken, PreGame preGame)
        {
            "Given a game"
                .Given(() => preGame = new PreGame("Test"));

            "And a player name".And(
                () => playerName = "Bryan");

            "And an invalid token"
                .And(() => invitationToken = Guid.NewGuid());

            "Then throws an error when trying to accept invitation"
                .Then(() => Assert.Throws<InvalidInvitationToken>(() => preGame.AcceptInvitation(playerName, invitationToken)));
        }

        [Scenario]
        public void accepting_an_invitation_to_game(string playerName, Guid invitationToken, PreGame preGame)
        {
            "Given a game"
                .Given(() => preGame = new PreGame("Test"));

            "With an invited player"
                .And(() =>
                {
                    playerName = "Bryan";
                    invitationToken = new Guid("7d9b4a47-b0e3-4aa3-965a-631b5a535de5");
                    preGame.InvitePlayer(playerName, () => invitationToken);
                });

            "When they accept the invitation with a valid token"
                .When(() => preGame.AcceptInvitation(playerName, invitationToken));

            "The invitation accepted event is raised"
                .Then(() =>
                {
                    var @event = (InvitationAccepted)preGame.Events.Last();
                    @event.PlayerName.ShouldBe(playerName);
                    @event.InvitationToken.ShouldBe(invitationToken);
                });
        }

        [Scenario]
        public void when_too_many_people_accept_the_invitation_then_an_exception_is_thrown(string playerName, IList<Guid> invitationTokens, PreGame preGame)
        {
            "Given the a game"
                .Given(() => preGame = new PreGame("Test"));

            "And 10 invitations"
                .And(() =>
                {
                    invitationTokens = new List<Guid>();
                    for (var x = 0; x <= 10; x++)
                    {
                        var invitationToken = new Guid();
                        invitationTokens.Add(invitationToken);
                        preGame.InvitePlayer("Bryan", () => invitationToken);
                    }
                });

            "When I invite 6 players"
                .When(() =>
                {
                    for (var x = 0; x < 6; x++)
                    {
                        var invitationToken = invitationTokens[x];
                        preGame.AcceptInvitation(playerName, invitationToken);
                    }
                });

            "Then I invite one more player an exception is thrown"
                .Then(() => Assert.Throws<TooManyPlayersException>(() => preGame.AcceptInvitation(playerName, invitationTokens[6])));
        }
    }

    public class InvalidInvitationToken : Exception
    {
    }

    public class PreGame
    {
        private const int MaxNumberOfPlayers = 6;

        private int numberOfPlayers;

        private readonly IList<Guid> sentInvitationTokens;

        public PreGame(string gameName)
        {
            this.sentInvitationTokens = new List<Guid>();
            this.Events = new List<object>();
            this.Events.Add(new GameCreated(gameName));
        }

        public IList<object> Events { get; set; }

        public void InvitePlayer(string playerName, Func<Guid> guidGenerator)
        {
            var invitationToken = guidGenerator();
            this.sentInvitationTokens.Add(invitationToken);
            this.Events.Add(new PlayerInvited(playerName, invitationToken));
        }

        public void AcceptInvitation(string playerName, Guid invitationToken)
        {
            if (this.numberOfPlayers >= MaxNumberOfPlayers)
            {
                throw new TooManyPlayersException();
            }

            if (!this.sentInvitationTokens.Contains(invitationToken))
            {
                throw new InvalidInvitationToken();
            }

            this.numberOfPlayers++;
            this.Events.Add(new InvitationAccepted(playerName, invitationToken));
        }
    }

    public class GameCreated
    {
        public GameCreated(string gameName)
        {
            this.GameName = gameName;
        }

        public string GameName { get; private set; }
    }

    public class PlayerInvited
    {
        public PlayerInvited(string playerName, Guid invitationToken)
        {
            this.PlayerName = playerName;
            this.InvitationToken = invitationToken;
        }

        public string PlayerName { get; private set; }

        public Guid InvitationToken { get; private set; }
    }

    public class InvitationAccepted
    {
        public InvitationAccepted(string playerName, Guid invitationToken)
        {
            this.PlayerName = playerName;
            this.InvitationToken = invitationToken;
        }

        public string PlayerName { get; private set; }

        public Guid InvitationToken { get; private set; }
    }

    public class TooManyPlayersException : Exception
    {
    }

    public class EventEnvelope
    {
        public object Claims { get; set; }

        public object Event { get; set; }
    }
}