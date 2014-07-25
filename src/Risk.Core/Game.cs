namespace Risk.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        public Game(string gameName, IDictionary<Guid, string> players, Board board)
        {
            this.Name = gameName;
            this.Board = board;
            this.Players = new Dictionary<Guid, Player>();

            var numberOfStartingUnits = GetNumberOfStartingUnits(players.Count);

            this.AddPlayers(players, numberOfStartingUnits);
        }

        public Board Board { get; set; }

        public string Name { get; private set; }

        public IDictionary<Guid, Player> Players { get; private set; }

        public Guid CurrentPlayersTurn { get; private set; }

        public void PlaceUnitOnBoard(Guid playerId, string territory)
        {
            this.Players[playerId].PlaceUnitOnBoard();
            this.Board.PlaceUnitOnTerritory(playerId, territory);
        }

        public void DecideWhoGoesFirst(Func<int> dice)
        {
            this.CurrentPlayersTurn = this.DecideWhoGoesFirst(dice, this.Players);
        }

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

        private Guid DecideWhoGoesFirst(Func<int> dice, IDictionary<Guid, Player> players)
        {
            foreach (var player in players.Values)
            {
                player.RollDice(dice);
            }

            var highestRoll = this.Players.Max(p => p.Value.LastDiceRoll);
            var highestScoringPlayers = this.Players.Where(m => m.Value.LastDiceRoll == highestRoll).ToDictionary(m => m.Key, m => m.Value);

            return highestScoringPlayers.Count() == 1 ? highestScoringPlayers.Single().Key : this.DecideWhoGoesFirst(dice, highestScoringPlayers);
        }

        private void AddPlayers(IDictionary<Guid, string> players, int numberOfStartingUnits)
        {
            foreach (var player in players)
            {
                this.Players.Add(player.Key, new Player(player.Value, numberOfStartingUnits, false));
            }

            if (players.Count == 2)
            {
                this.AddNeutralPlayer();
            }
        }

        private void AddNeutralPlayer()
        {
            this.Players.Add(Guid.Empty, new Player("Neutral", 40, true));
        }
    }
}