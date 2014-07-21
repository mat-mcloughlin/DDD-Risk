namespace Risk.Core
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        public Game(string gameName, IDictionary<Guid, string> players)
        {
            this.Name = gameName;
            this.Players = new Dictionary<Guid, Player>();

            var numberOfStartingUnits = GetNumberOfStartingUnits(players.Count);

            foreach (var player in players)
            {
                this.Players.Add(player.Key, new Player(player.Value, numberOfStartingUnits, false));
            }

            if (players.Count == 2)
            {
                this.AddNeutralPlayer();
            }
        }

        public string Name { get; private set; }

        public Dictionary<Guid, Player> Players { get; private set; }

        private static int GetNumberOfStartingUnits(int numberOfPlayers)
        {
            switch (numberOfPlayers)
            {
                case 2:
                    return 40;
                case 3:
                    return 35;
                case 4:
                    return 30;
                case 5:
                    return 25;
                case 6:
                    return 20;
                default:
                    throw new TooManyPlayersException();
            }
        }

        private void AddNeutralPlayer()
        {
            this.Players.Add(Guid.Empty, new Player("Neutral", 40, true));
        }
    }
}