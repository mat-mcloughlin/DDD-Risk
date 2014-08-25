//namespace Core.Facts.GameSetup
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    using Core.GameSetup;
//    using Core.GameSetup.Turns;

//    using Xbehave;

//    using Xunit;
//    using Xunit.Should;

//    public class PlayingATurn
//    {
//        [Scenario]
//        void Starting_a_new_turn(Guid playerId, Guid turnId, Turn turn, Board board)
//        {
//            "Given a player id"
//                .Given(() => turnId = Guid.NewGuid());

//            "And a player id"
//                .Given(() => playerId = Guid.NewGuid());

//            "With a number of infantry units"
//                .And(() => { });

//            "And the state of the board"
//                .And(() =>
//                    {
//                        var territory = new Territory(0, null);
//                        board = new Board(new Dictionary<string, Territory> { { "Territory", territory } });
//                    });

//            "When we start a new turn"
//                .When(() =>
//                {
//                    var command = new StartTurn(turnId, playerId, board);
//                    turn = new Turn(command);
//                });

//            "A new turn is started"
//                .Then(() =>
//                {
//                    var @event = (TurnStarted)turn.Events.Last();
//                    @event.PlayerId.ShouldBe(playerId);
//                    @event.TurnId.ShouldBe(turnId);
//                });
//        }

//        [Scenario]
//        void Player_places_an_infantry_unit_on_the_board(Guid playerId, Guid turnId, Turn turn, Board board)
//        {
//            "Given a turn"
//                .Given(() =>
//                    {
//                        turnId = Guid.NewGuid();
//                        playerId = Guid.NewGuid();
//                        var territory = new Territory(0, playerId);
//                        board = new Board(new Dictionary<string, Territory> { { "Territory", territory } });
//                        var command = new StartTurn(turnId, playerId, board);
//                        turn = new Turn(command);
//                    });

//            "When a player places a infantry unit"
//                .When(() =>
//                {
//                    var command = new PlaceInfantryUnit("Territory");
//                    turn.Handle(command);
//                });

//            "Then a new unit is placed"
//                .Then(() =>
//                {
//                    var @event = (InfantryUnitPlaced)turn.Events.Last();
//                    @event.TurnId.ShouldBe(turnId);
//                    @event.Territory.ShouldBe("Territory");
//                });
//        }

//        [Scenario]
//        void Player_trying_to_place_a_unit_on_a_territory_that_doesnt_exist(Guid playerId, Guid turnId, Turn turn, Board board)
//        {
//            "Given a turn"
//                .Given(() =>
//                {
//                    turnId = Guid.NewGuid();
//                    playerId = Guid.NewGuid();
//                    var territory = new Territory(0, null);
//                    board = new Board(new Dictionary<string, Territory> { { "Territory", territory } });
//                    var command = new StartTurn(turnId, playerId, board);
//                    turn = new Turn(command);
//                });

//            "When a player places a infantry unit on a non existant territory then an exception should be thrown"
//                .When(() =>
//                {
//                    var command = new PlaceInfantryUnit("TerritoryDoesntExist");
//                    Assert.Throws<InvalidTerritoryException>(() => turn.Handle(command));
//                });
//        }

//        [Scenario]
//        void Player_trying_to_place_a_unit_on_a_territory_that_is_already_occupied(Guid playerId, Guid turnId, Turn turn, Board board)
//        {
//            "Given a turn"
//                .Given(() =>
//                {
//                    turnId = Guid.NewGuid();
//                    playerId = Guid.NewGuid();
//                    var territory = new Territory(0, Guid.NewGuid());
//                    board = new Board(new Dictionary<string, Territory> { { "Territory", territory } });
//                    var command = new StartTurn(turnId, playerId, board);
//                    turn = new Turn(command);
//                });

//            "When a player places a infantry unit on a non existant territory then an exception should be thrown"
//                .When(() =>
//                {
//                    var command = new PlaceInfantryUnit("Territory");
//                    Assert.Throws<TerritoryAlreadyOccupiedException>(() => turn.Handle(command));
//                });
//        }

//        [Scenario]
//        void Player_trying_to_reinforce_a_territory_before_all_occupied(Guid playerId, Guid turnId, Turn turn, Board board)
//        {
//            "Given a turn"
//                .Given(() =>
//                {
//                    turnId = Guid.NewGuid();
//                    playerId = Guid.NewGuid();
//                    var territory = new Territory(1, playerId);
//                    var unoccupiedTerritory = new Territory(0, null);
//                    board = new Board(new Dictionary<string, Territory> { { "Territory", territory }, { "UnoccupiedTerritory", unoccupiedTerritory } });
//                    var command = new StartTurn(turnId, playerId, board);
//                    turn = new Turn(command);
//                });

//            "When a player places a infantry unit on a non existant territory then an exception should be thrown"
//                .When(() =>
//                {
//                    var command = new PlaceInfantryUnit("Territory");
//                    Assert.Throws<StillUnoccupiedTerritoriesException>(() => turn.Handle(command));
//                });
//        }
//    }
//}
