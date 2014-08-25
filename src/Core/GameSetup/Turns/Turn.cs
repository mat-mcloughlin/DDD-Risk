//namespace Core.GameSetup.Turns
//{
//    using System;
//    using System.Linq;

//    using Core.Infrastructure;

//    public class Turn : Topic
//    {
//        Guid _id;

//        Guid _playerId;

//        Board _board;

//        public Turn(StartTurn command)
//        {
//            Raise(new TurnStarted(command.TurnId, command.PlayerId, command.Board));
//        }

//        public void Handle(PlaceInfantryUnit command)
//        {
//            CheckTerritoryExists(command.Territory);
//            CheckTerritoryIsntOccupied(command.Territory);
//            CheckAllTerritoriesOccupiedBeforeReinforcingTerritory(command.Territory);
//            Raise(new InfantryUnitPlaced(_id, command.Territory));
//        }

//        void When(TurnStarted @event)
//        {
//            this._id = @event.TurnId;
//            this._playerId = @event.PlayerId;
//            this._board = @event.Board;
//        }

//        void When(InfantryUnitPlaced @event)
//        {
//            this._board.Territories[@event.Territory].Occupy(this._playerId);
//        }

//        void CheckAllTerritoriesOccupiedBeforeReinforcingTerritory(string territory)
//        {
//            if (_board.Territories[territory].NumberOfInfantryUnits > 0)
//            {
//                var numberOfUnoccupiedTerritories = _board.Territories.Values.Count(t => t.NumberOfInfantryUnits == 0);
//                if (numberOfUnoccupiedTerritories > 0)
//                {
//                    throw new StillUnoccupiedTerritoriesException();
//                }
//            }
//        }

//        void CheckTerritoryIsntOccupied(string territory)
//        {
//            if (_board.Territories[territory].OccupyingPlayerId != _playerId)
//            {
//                throw new TerritoryAlreadyOccupiedException();
//            }
//        }

//        void CheckTerritoryExists(string territory)
//        {
//            if (!_board.Territories.Keys.Contains(territory))
//            {
//                throw new InvalidTerritoryException();
//            }
//        }
//    }
//}
