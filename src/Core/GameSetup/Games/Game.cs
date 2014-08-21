namespace Core.GameSetup.Games
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Core.Infrastructure;

    public class Game : Topic
    {
        Guid _id;

        Players _players;

        string _name;

        Guid _currentPlayer;

        Board _board;

        private Guid _currentTurnToken;

        public Game(StartGame c, IDice dice, Func<Guid> generateGuid)
        {
            var startingPlayer = RollDiceUntilWinner(c.Players.Keys, dice);
            var numberOfStartingInfantryUnits = GetStartingInfantryUnits(c.Players.Count);
            var turnToken = generateGuid();

            Raise(new GameStarted(c.GameId, c.GameName, c.Players, startingPlayer, Board.Clear(), numberOfStartingInfantryUnits, turnToken));
        }

        public void Handle(EndTurn c, Func<Guid> generateGuid)
        {
            CheckTurnTokenIsValid(c.TurnToken);

            if (_players.StillHaveInfantryUnitsLeft())
            {
                var nextPlayer = _players.Next();
                var turnToken = generateGuid();
                Raise(new TurnEnded(turnToken, _currentPlayer, nextPlayer.Id, c.Board, nextPlayer.InfantryUnitsLeft));
            }
            else
            {
                // This phase has finished start proper game.
            }
        }

        void When(GameStarted e)
        {
            _id = e.GameId;
            _players = new Players(e.Players, e.NumberOfStartingInfantryUnits, e.StartingPlayer);
            _name = e.GameName;
            _currentPlayer = e.StartingPlayer;
            _currentTurnToken = e.TurnToken;
            _board = e.Board;
        }

        void When(TurnEnded e)
        {
            _board = e.Board;
            _players[e.CurrentPlayer].RemoveInfantryUnit();
            _currentPlayer = e.NextPlayer;
        }

        void CheckTurnTokenIsValid(Guid turnToken)
        {
            if (this._currentTurnToken != turnToken)
            {
                throw new InvalidTurnTokenException();
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
    }
}
