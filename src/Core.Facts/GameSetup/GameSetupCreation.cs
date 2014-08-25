//namespace Core.Facts.GameSetup
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    using Core.GameSetup;
//    using Core.GameSetup.Games;

//    using Xbehave;

//    using Xunit.Should;

//    public class GameSetupCreation
//    {
//        [Scenario]
//        [Example("game Name", 3, 35)]
//        [Example("game Name", 4, 30)]
//        [Example("game Name", 5, 25)]
//        [Example("game Name", 6, 20)]
//        void New_game_can_be_started(string gameName, int numberOfPlayers, int expectedNumberOfStartingUnits, Guid gameId, GameSetup game, Dice dice)
//        {
//            var players = new Dictionary<Guid, string>();
//            var turnGuid = new Guid("41a8cd9a-3eab-4c92-92d1-ccc7917fe669");
            
//            "Given a game name"
//                .Given(() => { });

//            "And a game Id"
//                .And(() => gameId = Guid.NewGuid());

//            "And a number of players"
//                .And(() =>
//                {
//                    for (var i = 0; i < numberOfPlayers; i++)
//                    {
//                        players.Add(Guid.NewGuid(), "Player" + i);
//                    }
//                });

//            "And a dice"
//                .And(() => dice = new Dice());

//            "When we start a game"
//                .When(() =>
//                {
//                    var command = new StartGameSetup(gameId, gameName, players);
//                    game = new GameSetup(command, dice, () => turnGuid);
//                });

//            "Then a game should be started with a number of players"
//                .Then(() =>
//                {
//                    var @event = (GameSetupStarted)game.Events.Last();
//                    @event.setupId.ShouldBe(gameId);
//                    @event.GameName.ShouldBe(gameName);
//                    @event.Players.Count.ShouldBe(numberOfPlayers);
//                    @event.NumberOfStartingInfantryUnits.ShouldBe(expectedNumberOfStartingUnits);
//                    @event.Board.ShouldNotBeNull();
//                    players.Keys.ShouldContain(@event.StartingPlayerId);
//                });
//        }
//    }
//}