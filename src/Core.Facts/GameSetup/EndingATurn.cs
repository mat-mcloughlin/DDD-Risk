namespace Core.Facts.GameSetup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Core.GameSetup;
    using Core.GameSetup.Games;
    using Core.GameSetup.Turns;

    using Xbehave;

    using Xunit;
    using Xunit.Should;

    public class EndingATurn
    {
        [Scenario]
        void Ending_a_turn_on_the_game(Game game)
        {
            var turnGuid = new Guid("e9f5a7cf-161b-4f47-ba10-ad9413f5791e");
            var players = new Dictionary<Guid, string>();

            "Given a game"
                .Given(() =>
                {
                    for (var i = 0; i < 3; i++)
                    {
                        players.Add(Guid.NewGuid(), "Player" + i);
                    }

                    game = TestableGame.Get(turnGuid, players);
                });

            "When we complete a turn"
                .When(() =>
                    {
                        var command = new EndTurn(turnGuid, new Board(new Dictionary<string, Territory>()));
                        game.Handle(command, () => turnGuid);
                    });

            "A turn should be ended"
                .Then(() =>
                {
                    var startingPlayer = ((GameStarted)game.Events.First()).StartingPlayer;

                    var @event = (TurnEnded)game.Events.Last();
                    @event.TurnToken.ShouldBe(turnGuid);
                    @event.Board.ShouldNotBeNull();
                    players.Keys.ShouldContain(@event.NextPlayer);
                    @event.NextPlayer.ShouldNotBe(startingPlayer);
                    @event.NumberOfInfantryUnitsLeft.ShouldBe(35);
                });
        }

        [Scenario]
        void Turn_cannot_be_ended_due_to_incorrect_id(Game game)
        {
            "Given a game"
                .Given(() =>
                {
                    var players = new Dictionary<Guid, string>();

                    for (var i = 0; i < 3; i++)
                    {
                        players.Add(Guid.NewGuid(), "Player" + i);
                    }

                    game = TestableGame.Get(Guid.NewGuid(), players);
                });

            "When we complete a turn with invalid id an error should be thrown"
                .When(() =>
                {
                    var command = new EndTurn(Guid.NewGuid(), new Board(new Dictionary<string, Territory>()));
                    Assert.Throws<InvalidTurnTokenException>(() => game.Handle(command, Guid.NewGuid));
                });
        }

        private static class TestableGame
        {
            public static Game Get(Guid turnGuid, Dictionary<Guid, string> players)
            {
                var dice = new Dice();

                Func<Guid> guidGenerator = () => turnGuid;

                var command = new StartGame(Guid.NewGuid(), "test", players);
                return new Game(command, dice, guidGenerator);
            }
        }
    }
}
