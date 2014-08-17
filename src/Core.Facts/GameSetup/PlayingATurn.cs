namespace Core.Facts.GameSetup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Core.GameSetup;

    using Xbehave;

    using Xunit.Should;

    public class PlayingATurn
    {
        [Scenario]
        public void Starting_a_new_turn(string playerName, Guid playerId, int numberOfInfantryUnits, Turn turn, StateOfTheBoard stateOfTheBoard)
        {
            "Given a player id"
                .Given(() => playerId = Guid.NewGuid());

            "And a player name"
                .And(() => { });

            "With a number of infantry units"
                .And(() => { });

            "And the state of the board"
                .And(() =>
                {
                    var territoryDto = new StateOfTheTerritory("Territory");
                    stateOfTheBoard = new StateOfTheBoard(new List<StateOfTheTerritory> { territoryDto });
                });

            "When we start a new turn"
                .When(() =>
                {
                    var command = new StartTurn(playerId, playerName, stateOfTheBoard);
                    turn = new Turn(command);
                });

            "A new turn is started"
                .Then(() =>
                {
                    var @event = (TurnStarted)turn.Events.Last();
                    @event.PlayerName.ShouldBe(playerName);
                });
        }
    }
}
