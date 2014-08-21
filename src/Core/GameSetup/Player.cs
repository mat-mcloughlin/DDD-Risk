namespace Core.GameSetup
{
    using System;

    public class Player
    {
        public Player(Guid id, string name, int infantryUnitsLeft)
        {
            this.Id = id;
            this.Name = name;
            this.InfantryUnitsLeft = infantryUnitsLeft;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public int InfantryUnitsLeft { get; private set; }

        public void RemoveInfantryUnit()
        {
            InfantryUnitsLeft--;    
        }
    }
}
