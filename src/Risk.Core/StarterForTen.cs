using System;
using Xbehave;
using System.Collections.Generic;
using System.Linq;
using Xunit.Should;

namespace Risk.Core
{
    public class StarterForTen
    {
        [Scenario]
        public void creating_a_new_game(string name, PreGame preGame)
        {
            "Given the game name"
                .Given(() => { });

            "When I create a new game"
                .When(() =>
                {
                    preGame = new PreGame(name);
                });

            "A game created event is raised"
                .Then(() =>
                {
                    var @event = preGame.Events.First();
                    @event.GameName.ShouldBe(name);
                });
        }
    }

    public class PreGame
    {
        public IList<GameCreated> Events
        {
            get;
            set;
        }
    }

    public class GameCreated
    {
        public string GameName { get; set; }
    }
}