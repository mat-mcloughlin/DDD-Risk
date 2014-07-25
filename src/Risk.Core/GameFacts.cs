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
                .When(() => game = new Game(gameName, players, new Board(new Dictionary<string, Continent>())));

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
                .When(() => game = new Game(gameName, players, new Board(new Dictionary<string, Continent>())));

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
                .When(() => game = new Game(gameName, players, new Board(new Dictionary<string, Continent>())));

            "Then one neutral should be added with 40 unplaced units"
                .Then(() =>
                    {
                        var neutralPlayers = game.Players.Values.Where(p => p.IsNeutral).ToList();
                        neutralPlayers.Count().ShouldBe(1);
                        neutralPlayers.First().UnplacedUnits.ShouldBe(40);
                    });
        }

        [Scenario]
        public void Player_places_unit_on_map(string continent, string territory, KeyValuePair<Guid, Player> player, TestableGame game)
        {
            "Given a game with two players"
                .Given(() => game = TestableGame.Create("game", 2));

            "And with a player"
                .And(() => player = game.Players.First());

            "And a territory inside a continent"
                .And(() =>
                    {
                        territory = "Alaska";
                        continent = "North America";
                    });

            "When a player places a unit on that territory"
                .When(() =>
                    {
                        player = game.Players.First();
                        game.PlaceUnitOnBoard(player.Key, territory);
                    });

            "Then their unplaced units drops by one and that territory's placed units increase by one, for that player"
                .Then(() =>
                    {
                        game.Board.Continents[continent].Territories[territory].PlacedUnits.ShouldBe(1);
                        game.Board.Continents[continent].Territories[territory].OccupyingPlayer.ShouldBe(player.Key);
                        player.Value.UnplacedUnits.ShouldBe(39);
                    });
        }

        public class TestableGame : Game
        {
            public TestableGame(string gameName, IDictionary<Guid, string> players)
                : base(gameName, players, Boards.DefaultBoard)
            {
            }

            public static TestableGame Create(string gameName, int numberOfPlayers)
            {
                var players = new Dictionary<Guid, string>();
                for (var i = 1; i <= numberOfPlayers; i++)
                {
                    var guid = Guid.NewGuid();
                    players.Add(guid, "Bryan" + i);
                }

                return new TestableGame(gameName, players);
            }
        }
    }
}
