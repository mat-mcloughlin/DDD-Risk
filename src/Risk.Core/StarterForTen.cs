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
            "Given a game gameName"
                .Given(() =>
                {
                    gameName = "Test";
                });

            "When I create a new game"
                .When(() =>
                {
                    preGame = new PreGame(gameName);
                });

            "A game created event is raised"
                .Then(() =>
                {
                    var @event = (GameCreated)preGame.Events.First();
                    @event.GameName.ShouldBe(gameName);
                });
        }

        [Scenario]
        public void inviting_player_to_game(string playerName, PreGame preGame)
        {
            "Given the a game"
                .Given(() =>
                {
                    preGame = new PreGame("Test");
                });

            "And a player name".And(
                () =>
                {
                    playerName = "Bryan";
                });

            "When I invite the player"
                .When(() =>
                {
                    preGame.InvitePlayer(playerName);
                });

            "A user invited event is raised"
                .Then(() =>
                {
                    var @event = (PlayerInvited)preGame.Events.Last();
                    @event.PlayerName.ShouldBe(playerName);
                });
        }

        [Scenario]
        public void accepting_an_invitation_to_game(string playerName, PreGame preGame)
        {
            "Given the a game"
                .Given(() =>
                {
                    preGame = new PreGame("Test");
                });

            "With an invited player"
                .And(() =>
                {
                    playerName = "Bryan";
                    preGame.InvitePlayer(playerName);
                });

            "When they accept the invitation"
                .When(() =>
                {
                    preGame.AcceptInvitation(playerName);
                });

            "The invitation accepted event is raised"
                .Then(() =>
                {
                    var @event = (InvitationAccepted)preGame.Events.Last();
                    @event.PlayerName.ShouldBe(playerName);
                });
        }

        [Scenario]
        public void when_too_many_people_accept_the_invitation_then_an_exception_is_thrown(string playerName, PreGame preGame)
        {
            "Given the a game"
                .Given(() =>
                {
                    preGame = new PreGame("Test");
                });

            "And a player name".And(
                () =>
                {
                    playerName = "Bryan";
                });

            "When I invite 6 players"
                .When(() =>
                {
                    for (var x = 0; x < 6; x++)
                    {
                        preGame.AcceptInvitation(playerName);
                    }
                });

            "Then I invite one more player an exception is thrown"
                .Then(() =>
                {
                    Assert.Throws<TooManyPlayersException>(() => preGame.AcceptInvitation(playerName));
                });
        }
    }

    public class PreGame
    {
        private const int MaxNumberOfPlayers = 6;

        private int numberOfPlayers;

        public PreGame(string gameName)
        {
            this.Events = new List<object>();
            this.Events.Add(new GameCreated(gameName));
        }

        public IList<object> Events { get; set; }

        public void InvitePlayer(string playerName)
        {
            this.Events.Add(new PlayerInvited(playerName));
        }

        public void AcceptInvitation(string playerName)
        {
            if (this.numberOfPlayers >= MaxNumberOfPlayers)
            {
                throw new TooManyPlayersException();
            }
            this.numberOfPlayers++;
            this.Events.Add(new InvitationAccepted(playerName));
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
        public PlayerInvited(string playerName)
        {
            this.PlayerName = playerName;
        }

        public string PlayerName { get; private set; }
    }

    public class InvitationAccepted
    {
        public InvitationAccepted(string playerName)
        {
            this.PlayerName = playerName;
        }

        public string PlayerName { get; private set; }
    }

    public class TooManyPlayersException : Exception
    {
    }
}