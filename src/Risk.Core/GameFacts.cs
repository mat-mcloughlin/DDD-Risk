namespace Risk.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Xbehave;

    using Xunit.Should;

    public class GameFacts
    {
        // Each player first counts out a number of infantry for initial deployment. 
        // The number of starting armies depends on the number of players. 
        // If two are playing, then each player counts out 40 infantry, plus 40 more from a different color set. 
        // This third set is neutral and only defends if attacked (the player not attacking rolls for the neutral armies). 
        // If three are playing, each player counts out 35 infantry; four players, 30 infantry; five players, 25 infantry; six players, 20 infantry.
        // Players then take turns claiming territories by placing an infantry on an unoccupied territory until all the territories are occupied.
        // Players then take turns placing their remaining armies on their territories. 
        // Having done this, the actual game begins with another roll of a dice, which is used to determine the playing order.

        [Scenario]
        [Example(3)]
        [Example(4)]
        [Example(5)]
        [Example(6)]
        public void Creating_a_game_adds_players_to_the_game_and_names_it(int numberOfPlayers, string gameName, Game game)
        {
            var players = new Dictionary<Guid, string>();

            "Given a game name"
                .Given(() => gameName = "Test");

            "And a number of players"
                .And(() =>
                    {
                        for (var i = 1; i <= numberOfPlayers; i++)
                        {
                            players.Add(Guid.NewGuid(), "Bryan");
                        }
                    });

            "When a game is created"
                .When(() => game = new Game(gameName, players));

            "Then the game is named and players added"
                .Then(() =>
                    {
                        game.Name.ShouldBe(gameName);
                        game.Players.Count.ShouldBe(numberOfPlayers);
                    });
        }

        [Scenario(Skip = "Needs implementing")]
        public void Creating_a_game_with_too_few_players_throws_an_exception()
        {
        }

        [Scenario(Skip = "Needs implementing")]
        public void Creating_a_game_with_too_many_players_throws_an_exception()
        {
        }

        [Scenario]
        [Example(2, 40)]
        [Example(3, 35)]
        [Example(4, 30)]
        [Example(5, 25)]
        [Example(6, 20)]
        public void Creating_a_game_gives_each_player_the_correct_number_of_units_dependent_on_number_of_players(int numberOfplayers, int numberOfUnplacedUnits, string gameName, Game game)
        {
            var players = new Dictionary<Guid, string>();

            "Given a game name"
                .Given(() => gameName = "Test");

            "And a number of players"
                .And(() =>
                    {
                        for (var i = 1; i <= numberOfplayers; i++)
                        {
                            players.Add(Guid.NewGuid(), "Bryan");
                        }
                    });

            "When a game is created"
                .When(() => game = new Game(gameName, players));

            "Then the each player should have x number of units"
                .Then(() =>
                    {
                        foreach (var player in game.Players.Values)
                        {
                            player.UnplacedUnits.ShouldBe(numberOfUnplacedUnits);
                        }
                    });
        }

        [Scenario]
        public void Creating_a_game_with_only_two_players_adds_a_neutral_army(int numberOfplayers, string gameName, Game game)
        {
            var players = new Dictionary<Guid, string>();

            "Given a game name"
                .Given(() => gameName = "Test");

            "And a number two players"
                .And(() =>
                {
                    for (var i = 1; i <= 2; i++)
                    {
                        players.Add(Guid.NewGuid(), "Bryan");
                    }
                });

            "When a game is created"
                .When(() => game = new Game(gameName, players));

            "Then one neutral should be added with 40 unplaced units"
                .Then(() =>
                    {
                        var neutralPlayers = game.Players.Values.Where(p => p.IsNeutral).ToList();
                        neutralPlayers.Count().ShouldBe(1);
                        neutralPlayers.First().UnplacedUnits.ShouldBe(40);
                    });
        }
    }

    public class Game
    {
        public Game(string gameName, IDictionary<Guid, string> players)
        {
            this.Name = gameName;
            this.Players = new Dictionary<Guid, Player>();

            var numberOfStartingUnits = GetNumberOfStartingUnits(players.Count);

            foreach (var player in players)
            {
                this.Players.Add(player.Key, new Player(player.Value, numberOfStartingUnits, false));
            }

            if (players.Count == 2)
            {
                this.AddNeutralPlayer();
            }
        }

        public string Name { get; private set; }

        public Dictionary<Guid, Player> Players { get; private set; }

        private static int GetNumberOfStartingUnits(int numberOfPlayers)
        {
            switch (numberOfPlayers)
            {
                case 2:
                    return 40;
                case 3:
                    return 35;
                case 4:
                    return 30;
                case 5:
                    return 25;
                case 6:
                    return 20;
                default:
                    throw new TooManyPlayersException();
            }
        }

        private void AddNeutralPlayer()
        {
            this.Players.Add(Guid.Empty, new Player("Neutral", 40, true));
        }
    }

    public class Player
    {
        public Player(string name, int numberOfStartingUnits, bool isNeutral)
        {
            this.Name = name;
            this.UnplacedUnits = numberOfStartingUnits;
            this.IsNeutral = isNeutral;
        }

        public string Name { get; private set; }

        public int UnplacedUnits { get; private set; }

        public bool IsNeutral { get; private set; }
    }
}
