namespace Risk.Core
{
    using System.Collections.Generic;

    public class Continent 
    {
        public Continent(IDictionary<string, Territory> territories)
        {
            this.Territories = territories;
        }

        public IDictionary<string, Territory> Territories { get; private set; }
    }
}
