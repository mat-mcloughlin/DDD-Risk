namespace Core.Facts.GameSetup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Core.GameSetup;

    using Xbehave;

    using Xunit.Should;

    public class GameSetupCreation
    {
        [Scenario]
        [Example("game Name", 6)]
        public void New_game_can_be_started(string gameName, int numberOfPlayers, Guid gameId, Game game)
        {
            var players = new Dictionary<Guid, string>();
            
            "Given a game name"
                .Given(() => { });

            "And a game Id"
                .And(() => gameId = Guid.NewGuid());

            "And a number of players"
                .And(() =>
                {
                    for (var i = 0; i < numberOfPlayers; i++)
                    {
                        players.Add(Guid.NewGuid(), "Player" + i);
                    }
                });

            "When we start a game"
                .When(() =>
                {
                    var command = new StartGame(gameId, gameName, players);
                    game = new Game(command);
                });

            "Then a game should be started with a number of players"
                .Then(() =>
                {
                    var @event = (GameStarted)game.Events.Last();
                    @event.GameId.ShouldBe(gameId);
                    @event.GameName.ShouldBe(gameName);
                    @event.Players.Count.ShouldBe(numberOfPlayers);
                });
        }
    }
}