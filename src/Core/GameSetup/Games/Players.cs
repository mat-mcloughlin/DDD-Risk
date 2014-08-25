namespace Core.GameSetup.Games
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Players
    {
        private readonly IDictionary<Guid, int> _players;

        public Players(IEnumerable<Guid> players, int numberOfStartingInfantryUnits)
        {
            _players = players.ToDictionary(p => p, p => numberOfStartingInfantryUnits);
        }
        
        public int this[Guid index]
        {
            get
            {
                return _players[index];
            }

            set
            {
                _players[index] = value;
            }
        }

        public Guid Next(Guid currentPlayer)
        {
            var currentPlayerIndex = _players.Keys.ToList().IndexOf(currentPlayer);
            var nextPlayerIndex = currentPlayerIndex == _players.Count - 1 ? 0 : currentPlayerIndex + 1;
            return _players.Keys.ToList()[nextPlayerIndex];
        }

        public bool StillHaveInfantryUnitsLeft()
        {
            return _players.Values.Any(p => p > 0);
        }
    }
}
