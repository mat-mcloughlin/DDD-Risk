namespace Risk.Core
{
    using System.Collections.Generic;

    public static class Boards
    {
        public static Board DefaultBoard = new Board(new Dictionary<string, Continent>
            {
                {
                    "North America", new Continent(new Dictionary<string, Territory>
                    { 
                        { "Alaska", new Territory() },
                        { "Alberta", new Territory() },
                        { "Central America", new Territory() },
                        { "Eastern United States", new Territory() },
                        { "Greenland", new Territory() },
                        { "Northwest Territory", new Territory() },
                        { "Ontario", new Territory() },
                        { "Quebec", new Territory() },
                        { "Western United States", new Territory() }
                    })
                },
                {
                    "South America", new Continent(new Dictionary<string, Territory>
                    { 
                        { "Argentina", new Territory() },
                        { "Brazil", new Territory() },
                        { "Peru", new Territory() },
                        { "Venezuela", new Territory() }
                    })
                },
                {
                    "Europe", new Continent(new Dictionary<string, Territory>
                    { 
                        { "Great Britain", new Territory() },
                        { "Iceland", new Territory() },
                        { "North Europe", new Territory() },
                        { "Scandinavia", new Territory() },
                        { "Southern Europe", new Territory() },
                        { "Ukraine", new Territory() },
                        { "Western Europe", new Territory() }
                    })
                },
                {
                    "Africa", new Continent(new Dictionary<string, Territory>
                    { 
                        { "Congo", new Territory() },
                        { "East Africa", new Territory() },
                        { "Egypt", new Territory() },
                        { "Madagascar", new Territory() },
                        { "North Africa", new Territory() },
                        { "South Africa", new Territory() }
                    })
                },
                {
                    "Asia", new Continent(new Dictionary<string, Territory>
                    { 
                        { "Afghanistan", new Territory() },
                        { "China", new Territory() },
                        { "India", new Territory() },
                        { "Irkutsk", new Territory() },
                        { "Japan", new Territory() },
                        { "Kamchatka", new Territory() },
                        { "Mongolia", new Territory() },
                        { "Siam", new Territory() },
                        { "Siberia", new Territory() },
                        { "Ural", new Territory() },
                        { "Yakutsk", new Territory() },
                        { "Middle East", new Territory() }
                    })
                },
                {
                    "Australia", new Continent(new Dictionary<string, Territory>
                    { 
                        { "Eastern Australia", new Territory() },
                        { "Indonesia", new Territory() },
                        { "New Guinea", new Territory() },
                        { "Western Australia", new Territory() }
                    })
                }
            });
    }
}
