namespace Core.GameSetup.Games
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CommonDomain.Core;

    using Core.GameSetup.Turns;

    public class Game : AggregateBase
    {
        Guid _gameId;

        Players _players;

        Guid _currentPlayerId;

        Board _board;

        public Game(Guid replaceMe, Guid gameId, IList<Guid> players, IDice dice)
        {
            var startingPlayer = RollDiceUntilWinner(players, dice);
            var numberOfStartingInfantryUnits = GetStartingInfantryUnits(players.Count);

            RaiseEvent(new GameStarted(replaceMe, gameId, players, startingPlayer, Board.Clear(), numberOfStartingInfantryUnits));
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
                RaiseEvent(new InfantryUnitPlaced(_currentPlayerId, nextPlayer, territory));
            }
            else
            {
                // This phase has finished start proper game.
            }
        }

        void Handle(GameStarted e)
        {
            Id = e.ReplaceMe;
            _gameId = e.GameId;
            _players = new Players(e.Players, e.NumberOfStartingInfantryUnits);
            _currentPlayerId = e.StartingPlayerId;
            _board = e.Board;
        }

        void Handle(InfantryUnitPlaced e)
        {
            _board.Territories[e.Territory].OccupyingPlayerId = e.CurrentPlayerId;
            _board.Territories[e.Territory].NumberOfInfantryUnits++;
            _players[e.CurrentPlayerId]--;

            _currentPlayerId = e.NextPlayer;
        }

        void CheckPlayerIsCurrentPlayer(Guid playerId)
        {
            if (playerId != this._currentPlayerId)
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
                    throw new TooManyPlayersException();
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
            if (_board.Territories[territory].OccupyingPlayerId != playerId)
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
