namespace Core.GameSetup.Games
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Players
    {
        private readonly List<Player> _players;

        private int _currentPlayer;

        public Players(IEnumerable<KeyValuePair<Guid, string>> players, int numberOfStartingInfantryUnits, Guid currentPlayer)
        {
            _players = new List<Player>();
            foreach (var player in players)
            {
                _players.Add(new Player(player.Key, player.Value, numberOfStartingInfantryUnits));

                if (player.Key == currentPlayer)
                {
                    _currentPlayer = _players.Count - 1;
                }
            }
        }

        public Player this[Guid index]
        {
            get
            {
                return _players.SingleOrDefault(p => p.Id == index);
            }
        }

        public Player Next()
        {
            var nextIndex = _currentPlayer == _players.Count - 1 ? 0 : _currentPlayer + 1;
            _currentPlayer = nextIndex;
            return _players[nextIndex];
        }

        public bool StillHaveInfantryUnitsLeft()
        {
            return _players.Any(p => p.InfantryUnitsLeft > 0);
        }
    }
}
