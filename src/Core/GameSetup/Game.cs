namespace Core.GameSetup
{
    using System;
    using System.Collections.Generic;

    using Core.Infrastructure;

    public class Game : Topic
    {
        private Guid id;

        private IDictionary<Guid, string> players;

        private string name;

        public Game(StartGame command)
        {
            this.Raise(new GameStarted(command.GameId, command.GameName, command.Players));
        }

        private void Handle(GameStarted @event)
        {
            this.id = @event.GameId;
            this.players = @event.Players;
            this.name = @event.GameName;
        }
    }
}
