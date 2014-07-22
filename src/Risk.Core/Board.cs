namespace Risk.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Board
    {
        public Board(IDictionary<string, Continent> continents)
        {
            this.Continents = continents;
        }

        public IDictionary<string, Continent> Continents { get; set; }

        public void PlaceUnitOnTerritory(Guid playerId, string territoryKey)
        {
            var territory = this.Continents.SelectMany(c => c.Value.Territories).Single(t => t.Key == territoryKey).Value;
            territory.PlaceUnit(playerId);
        }
    }
}