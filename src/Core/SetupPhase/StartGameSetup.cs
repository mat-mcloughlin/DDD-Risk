namespace Core.SetupPhase
{
    using System;
    using System.Collections.Generic;

    public class StartGameSetup
    {
        public StartGameSetup(Guid gameSetupId, Guid gameId, string gameName, IList<Guid> players)
        {
            GameSetupId = gameSetupId;
            Players = players;
            GameId = gameId;
            GameName = gameName;
        }

        public IList<Guid> Players { get; private set; }

        public Guid GameId { get; private set; }

        public string GameName { get; private set; }

        public Guid GameSetupId { get; private set; }
    }
}