namespace Core.SetupPhase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CommonDomain.Core;

    using Core.SetupPhase.Exceptions;

    public class GameSetup : AggregateBase
    {
        Guid _gameId;

        Players _players;

        Guid _currentPlayerId;

        Board _board;

        public GameSetup(Guid gameSetupId, Guid gameId, IList<Guid> players, IDice dice)
        {
            var startingPlayer = RollDiceUntilWinner(players, dice);
            var numberOfStartingInfantryUnits = GetStartingInfantryUnits(players.Count);

            RaiseEvent(new GameSetupStarted(gameSetupId, gameId, players, startingPlayer, Board.Clear(), numberOfStartingInfantryUnits));
        }

        private GameSetup()
        {
        }

        public void PlaceInfantryUnit(Guid playerId, string territory)
        {
            CheckPlayerIsCurrentPlayer(playerId);
            CheckTerritoryExists(territory);
            CheckTerritoryIsntOccupied(playerId, territory);
            CheckAllTerritoriesOccupiedBeforeReinforcingTerritory(territory);

            if (_players.StillHaveInfantryUnitsLeft())
            {
                var nextPlayer = _players.Next(playerId);
                RaiseEvent(new InfantryUnitPlaced(Id, _currentPlayerId, nextPlayer, territory));
            }
            else
            {
                // This phase has finished start proper game.
            }
        }

        void Apply(GameSetupStarted e)
        {
            Id = e.GameSetupId;
            _gameId = e.GameId;
            _players = new Players(e.Players, e.NumberOfStartingInfantryUnits);
            _currentPlayerId = e.StartingPlayerId;
            _board = e.Board;
        }

        void Apply(InfantryUnitPlaced e)
        {
            _board.Territories[e.Territory].OccupyingPlayerId = e.CurrentPlayerId;
            _board.Territories[e.Territory].NumberOfInfantryUnits++;
            _players[e.CurrentPlayerId]--;

            _currentPlayerId = e.NextPlayer;
        }

        void CheckPlayerIsCurrentPlayer(Guid playerId)
        {
            if (playerId != _currentPlayerId)
            {
                throw new NotPlayersTurnException();
            }
        }

        int GetStartingInfantryUnits(int numberOfPlayers)
        {
            switch (numberOfPlayers)
            {
                case 3:
                    return 35;
                case 4:
                    return 30;
                case 5:
                    return 25;
                case 6:
                    return 20;
                default:
                    throw new InvalidNumberOfPlayersException();
            }
        }

        Guid RollDiceUntilWinner(IEnumerable<Guid> players, IDice dice)
        {
            var playerRolls = players
                .Select(p => new { Player = p, Roll = dice.Roll() })
                .ToList();

            var highestRollers = playerRolls
                .Where(p => p.Roll == playerRolls.Max(r => r.Roll))
                .Select(p => p.Player)
                .ToList();

            return highestRollers.Count() == 1 ? highestRollers.Single() : RollDiceUntilWinner(highestRollers, dice);
        }

        void CheckTerritoryExists(string territory)
        {
            if (!_board.Territories.Keys.Contains(territory))
            {
                throw new InvalidTerritoryException();
            }
        }

        void CheckTerritoryIsntOccupied(Guid playerId, string territory)
        {
            var territoryObject = _board.Territories[territory];
            if (territoryObject.OccupyingPlayerId != playerId && territoryObject.OccupyingPlayerId.HasValue)
            {
                throw new TerritoryAlreadyOccupiedException();
            }
        }

        void CheckAllTerritoriesOccupiedBeforeReinforcingTerritory(string territory)
        {
            if (_board.Territories[territory].NumberOfInfantryUnits > 0)
            {
                var stillUnoccupiedTerritories = _board.Territories.Values.Any(t => t.NumberOfInfantryUnits == 0);
                if (stillUnoccupiedTerritories)
                {
                    throw new StillUnoccupiedTerritoriesException();
                }
            }
        }
    }
}
