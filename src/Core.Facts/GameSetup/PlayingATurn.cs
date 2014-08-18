namespace Core.Facts.GameSetup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Core.GameSetup;

    using Xbehave;

    using Xunit;
    using Xunit.Should;

    public class PlayingATurn
    {
        [Scenario]
        public void Starting_a_new_turn(Guid playerId, Guid turnId, Turn turn, StateOfTheBoardDto stateOfTheBoard)
        {
            "Given a player id"
                .Given(() => turnId = Guid.NewGuid());

            "And a player id"
                .Given(() => playerId = Guid.NewGuid());

            "With a number of infantry units"
                .And(() => { });

            "And the state of the board"
                .And(() =>
                    {
                        var territoryDto = new StateOfTheTerritoryDto(0, null);
                        stateOfTheBoard = new StateOfTheBoardDto(new Dictionary<string, StateOfTheTerritoryDto> { { "Territory", territoryDto } });
                    });

            "When we start a new turn"
                .When(() =>
                {
                    var command = new StartTurn(turnId, playerId, stateOfTheBoard);
                    turn = new Turn(command);
                });

            "A new turn is started"
                .Then(() =>
                {
                    var @event = (TurnStarted)turn.Events.Last();
                    @event.PlayerId.ShouldBe(playerId);
                    @event.TurnId.ShouldBe(turnId);
                });
        }

        [Scenario]
        public void Player_places_an_infantry_unit_on_the_board(Guid playerId, Guid turnId, Turn turn, StateOfTheBoardDto stateOfTheBoard)
        {
            "Given a turn"
                .Given(() =>
                    {
                        turnId = Guid.NewGuid();
                        playerId = Guid.NewGuid();
                        var territoryDto = new StateOfTheTerritoryDto(0, playerId);
                        stateOfTheBoard = new StateOfTheBoardDto(new Dictionary<string, StateOfTheTerritoryDto> { { "Territory", territoryDto } });
                        var command = new StartTurn(turnId, playerId, stateOfTheBoard);
                        turn = new Turn(command);
                    });

            "When a player places a infantry unit"
                .When(() =>
                {
                    var command = new PlaceInfantryUnit("Territory");
                    turn.Handle(command);
                });

            "Then a new unit is placed"
                .Then(() =>
                {
                    var @event = (InfantryUnitPlaced)turn.Events.Last();
                    @event.TurnId.ShouldBe(turnId);
                    @event.Territory.ShouldBe("Territory");
                });
        }

        [Scenario]
        public void Player_trying_to_place_a_unit_on_a_territory_that_doesnt_exist(Guid playerId, Guid turnId, Turn turn, StateOfTheBoardDto stateOfTheBoard)
        {
            "Given a turn"
                .Given(() =>
                {
                    turnId = Guid.NewGuid();
                    playerId = Guid.NewGuid();
                                        var territoryDto = new StateOfTheTerritoryDto(0, null);
                    stateOfTheBoard = new StateOfTheBoardDto(new Dictionary<string, StateOfTheTerritoryDto> { { "Territory", territoryDto } });
                    var command = new StartTurn(turnId, playerId, stateOfTheBoard);
                    turn = new Turn(command);
                });

            "When a player places a infantry unit on a non existant territory then an exception should be thrown"
                .When(() =>
                {
                    var command = new PlaceInfantryUnit("TerritoryDoesntExist");
                    Assert.Throws<InvalidTerritoryException>(() => turn.Handle(command));
                });
        }

        [Scenario]
        public void Player_trying_to_place_a_unit_on_a_territory_that_is_already_occupied(Guid playerId, Guid turnId, Turn turn, StateOfTheBoardDto stateOfTheBoard)
        {
            "Given a turn"
                .Given(() =>
                {
                    turnId = Guid.NewGuid();
                    playerId = Guid.NewGuid();
                    var territoryDto = new StateOfTheTerritoryDto(0, Guid.NewGuid());
                    stateOfTheBoard = new StateOfTheBoardDto(new Dictionary<string, StateOfTheTerritoryDto> { { "Territory", territoryDto } });
                    var command = new StartTurn(turnId, playerId, stateOfTheBoard);
                    turn = new Turn(command);
                });

            "When a player places a infantry unit on a non existant territory then an exception should be thrown"
                .When(() =>
                {
                    var command = new PlaceInfantryUnit("Territory");
                    Assert.Throws<TerritoryAlreadyOccupiedException>(() => turn.Handle(command));
                });
        }

        [Scenario]
        public void Player_trying_to_reinforce_a_territory_before_all_occupied(Guid playerId, Guid turnId, Turn turn, StateOfTheBoardDto stateOfTheBoard)
        {
            "Given a turn"
                .Given(() =>
                {
                    turnId = Guid.NewGuid();
                    playerId = Guid.NewGuid();
                    var territoryDto = new StateOfTheTerritoryDto(1, playerId);
                    var unoccupiedTerritoryDto = new StateOfTheTerritoryDto(0, null);
                    stateOfTheBoard = new StateOfTheBoardDto(new Dictionary<string, StateOfTheTerritoryDto> { { "Territory", territoryDto }, { "UnoccupiedTerritory", unoccupiedTerritoryDto } });
                    var command = new StartTurn(turnId, playerId, stateOfTheBoard);
                    turn = new Turn(command);
                });

            "When a player places a infantry unit on a non existant territory then an exception should be thrown"
                .When(() =>
                {
                    var command = new PlaceInfantryUnit("Territory");
                    Assert.Throws<StillUnoccupiedTerritoriesException>(() => turn.Handle(command));
                });
        }
    }
}
