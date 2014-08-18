namespace Core.GameSetup
{
    using System;

    public class InfantryUnitPlaced
    {
        public InfantryUnitPlaced(Guid turnId, string territory)
        {
            this.TurnId = turnId;
            this.Territory = territory;
        }

        public Guid TurnId { get; private set; }

        public string Territory { get; private set; }
    }
}