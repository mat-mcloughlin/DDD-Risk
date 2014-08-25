namespace Core.SetupPhase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Players
    {
        private readonly IDictionary<Guid, int> _players;

        public Players(IEnumerable<Guid> players, int numberOfStartingInfantryUnits)
        {
            this._players = players.ToDictionary(p => p, p => numberOfStartingInfantryUnits);
        }
        
        public int this[Guid index]
        {
            get
            {
                return this._players[index];
            }

            set
            {
                this._players[index] = value;
            }
        }

        public Guid Next(Guid currentPlayer)
        {
            var currentPlayerIndex = this._players.Keys.ToList().IndexOf(currentPlayer);
            var nextPlayerIndex = currentPlayerIndex == this._players.Count - 1 ? 0 : currentPlayerIndex + 1;
            return this._players.Keys.ToList()[nextPlayerIndex];
        }

        public bool StillHaveInfantryUnitsLeft()
        {
            return this._players.Values.Any(p => p > 0);
        }
    }
}
