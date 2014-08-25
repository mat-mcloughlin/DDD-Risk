namespace Core.GameSetup
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Board
    {
        public Board(ReadOnlyDictionary<string, Territory> territories)
        {
            this.Territories = territories;
        }

        public ReadOnlyDictionary<string, Territory> Territories { get; private set; }

        public static Board Clear()
        {
            return new Board(new ReadOnlyDictionary<string, Territory>(new Dictionary<string, Territory>
            {
                { "Alaska", new Territory() },
                { "Alberta", new Territory() },
                { "Central America", new Territory() },
                { "Eastern United States", new Territory() },
                { "Greenland", new Territory() },
                { "Northwest Territory", new Territory() },
                { "Ontario", new Territory() },
                { "Quebec", new Territory() },
                { "Western United States", new Territory() },
                { "Argentina", new Territory() },
                { "Brazil", new Territory() },
                { "Peru", new Territory() },
                { "Venezuela", new Territory() },
                { "Great Britain", new Territory() },
                { "Iceland", new Territory() },
                { "Northern Europe", new Territory() },
                { "Southern Europe", new Territory() },
                { "Ukraine", new Territory() },
                { "Western Europe", new Territory() },
                { "Congo", new Territory() },
                { "East Africa", new Territory() },
                { "Madagascar", new Territory() },
                { "North Africa", new Territory() },
                { "South Africa", new Territory() },
                { "Afghanistan", new Territory() },
                { "China", new Territory() },
                { "India", new Territory() },
                { "Irkutsk", new Territory() },
                { "Japan", new Territory() },
                { "Kamchatka", new Territory() },
                { "Middle East", new Territory() },
                { "Mongolia", new Territory() },
                { "Siam", new Territory() },
                { "Siberia", new Territory() },
                { "Ural", new Territory() },
                { "Yakutsk", new Territory() },
                { "Eastern Australia", new Territory() },
                { "Indonesia", new Territory() },
                { "New Guinea", new Territory() },
                { "Western Australia", new Territory() }
            }));
        }
    }
}