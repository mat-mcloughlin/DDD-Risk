namespace Core.GameSetup.Turns
{
    using System;
    using System.Linq;

    using Core.Infrastructure;

    public class Turn : Topic
    {
        private Guid id;

        private Guid playerId;

        private Board stateOfBoard;

        public Turn(StartTurn command)
        {
            this.Raise(new TurnStarted(command.TurnId, command.PlayerId, command.Board));
        }
        
        public void Handle(PlaceInfantryUnit command)
        {
            this.CheckTerritoryExists(command.Territory);
            this.CheckTerritoryIsntOccupied(command.Territory);
            this.CheckAllTerritoriesOccupiedBeforeReinforcingTerritory(command.Territory);
            this.Raise(new InfantryUnitPlaced(this.id, command.Territory));
        }

        private void CheckAllTerritoriesOccupiedBeforeReinforcingTerritory(string territory)
        {
            if (this.stateOfBoard.Territories[territory].NumberOfInfantryUnits > 0)
            {
                var numberOfUnoccupiedTerritories = this.stateOfBoard.Territories.Values.Count(t => t.NumberOfInfantryUnits == 0);
                if (numberOfUnoccupiedTerritories > 0)
                {
                    throw new StillUnoccupiedTerritoriesException();
                }
            }
        }

        private void CheckTerritoryIsntOccupied(string territory)
        {
            if (this.stateOfBoard.Territories[territory].OccupyingPlayerId != this.playerId)
            {
                throw new TerritoryAlreadyOccupiedException();
            }
        }

        private void CheckTerritoryExists(string territory)
        {
            if (!this.stateOfBoard.Territories.Keys.Contains(territory))
            {
                throw new InvalidTerritoryException();
            }
        }

        private void When(TurnStarted @event)
        {
            this.id = @event.TurnId;
            this.playerId = @event.PlayerId;
            this.stateOfBoard = (Board)@event.Board;
        }

        private void When(InfantryUnitPlaced @event)
        {
            this.stateOfBoard.Territories[@event.Territory].Occupy(this.playerId);
        }
    }
}
