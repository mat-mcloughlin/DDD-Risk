namespace Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Autofac;

    using Core.Infrastructure;
    using Core.InvitationPhase;
    using Core.SetupPhase;

    internal class Program
    {
        private static CommandDispatcher dispatcher;

        private static void Main(string[] args)
        {
            var container = AutofacSetup.Build();

            dispatcher = container.Resolve<CommandDispatcher>();

            var lobbyId = Guid.NewGuid();
            var gameId = Guid.NewGuid();

            Console2.WriteLine("# Creating Game #", ConsoleColor.Red);
            var createLobby = new CreateLobby(lobbyId, gameId, "Test Game", Guid.NewGuid(), "Mat");
            dispatcher.Dispatch(createLobby);

            Console.ReadLine();
            Console2.WriteLine("# Inviting Richard #", ConsoleColor.Red);

            var invitationToken = Guid.NewGuid();
            var playerId = Guid.NewGuid();
            var invitePlayer = new InvitePlayer(lobbyId, playerId, "Richard", invitationToken);
            dispatcher.Dispatch(invitePlayer);

            Console.ReadLine();
            Console2.WriteLine("# Accepting Invitation #", ConsoleColor.Red);
            var acceptInvitation = new AcceptInvitation(lobbyId, invitationToken);
            dispatcher.Dispatch(acceptInvitation);

            Console.ReadLine();
            Console2.WriteLine("# Inviting Matt #", ConsoleColor.Red);
            var invitationToken2 = Guid.NewGuid();
            var invitePlayer2 = new InvitePlayer(lobbyId, Guid.NewGuid(), "Matt", invitationToken2);
            dispatcher.Dispatch(invitePlayer2);

            Console.ReadLine();
            Console2.WriteLine("# Accepting Invitation #", ConsoleColor.Red);
            var acceptInvitation2 = new AcceptInvitation(lobbyId, invitationToken2);
            dispatcher.Dispatch(acceptInvitation2);

            Console.ReadLine();
            Console2.WriteLine("# Starting Game #", ConsoleColor.Red);
            var gameSetupId = Guid.NewGuid();
            var startGame = new StartGame(lobbyId, gameSetupId);
            dispatcher.Dispatch(startGame);

            Console.ReadLine();

            //var boardSetupId = new Guid("4c7e5f0fc0bf4d28a63ba9b0253bb9f1");
            //var playerId = new Guid("59fbb53f-2c86-4b13-a6e5-740ffefdb2a7");

            //var placeInfantryUnit = new PlaceInfantryUnit(boardSetupId, playerId, "Alaska");
            //dispatcher.Dispatch(placeInfantryUnit);
        }

        public static void TakeTurn(Guid gameSetupId, Guid playerId)
        {
            Console.WriteLine();
            Console.WriteLine("Select Territory: ");

            ConsoleKeyInfo key;

            var currentTerritory = string.Empty;
            var textEntered = new StringBuilder();
            do
            {
                key = Console.ReadKey();
                textEntered.Append(key.KeyChar);

                if (key.Key != ConsoleKey.Enter)
                {
                    currentTerritory = Board.Get(textEntered.ToString());
                }
                Console.Write("\r" + currentTerritory);
                Console.SetCursorPosition(textEntered.Length, Console.CursorTop);
            }
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            Console.WriteLine();

            Console2.WriteLine("#" + playerId + " playing Turn #", ConsoleColor.Red);
            var command = new PlaceInfantryUnit(gameSetupId, playerId, currentTerritory);
            dispatcher.Dispatch(command);

        }
    }

    public class Observer : IConsume<LobbyCreated>, IConsume<PlayerInvited>, IConsume<InvitationAccepted>, IConsume<GameSetupStarted>, IConsume<InfantryUnitPlaced>
    {
        public void Consume(LobbyCreated e)
        {
            Console.WriteLine("Lobby Created");
            Console.WriteLine("Host Id: " + e.HostId);
            Console.WriteLine("Host Name: " + e.HostName);
            Console.WriteLine("Game Name: " + e.GameName);
        }

        public void Consume(PlayerInvited e)
        {
            Console.WriteLine("Player Invited");
            Console.WriteLine("Player Id: " + e.PlayerId);
            Console.WriteLine("Player Name: " + e.PlayerName);
            Console.WriteLine("Invitation Token: " + e.InvitationToken);
        }

        public void Consume(InvitationAccepted e)
        {
            Console.WriteLine("Invitation Accepted");
            Console.WriteLine("Player Id: " + e.PlayerId);
            Console.WriteLine("Player Name: " + e.PlayerName);
            Console.WriteLine("Invitation Token: " + e.InvitationToken);
        }

        public void Consume(GameSetupStarted e)
        {
            Console.WriteLine("Game Setup Started");
            Console.WriteLine("Game Setup Id: " + e.GameSetupId);
            Console.WriteLine("Number of Players: " + e.Players.Count);
            Console.WriteLine("Number of Starting Units: " + e.NumberOfStartingInfantryUnits);
            Console.WriteLine("Starting Player: " + e.StartingPlayerId);

            Program.TakeTurn(e.GameSetupId, e.StartingPlayerId);
        }

        public void Consume(InfantryUnitPlaced e)
        {
            Console.WriteLine("Infantry Unit Placed");
            Console.WriteLine("Player: " + e.CurrentPlayerId);
            Console.WriteLine("Territory: " + e.Territory);
            Console.WriteLine("Next Player: " + e.NextPlayerId);

            Program.TakeTurn(e.GameSetupId, e.NextPlayerId);
        }
    }

    public static class Board
    {
        private static readonly List<string> Territories = new List<string>
        {
            "Alaska",
            "Alberta",
            "Central America",
            "Eastern United States",
            "Greenland",
            "Northwest Territory",
            "Ontario",
            "Quebec",
            "Western United States",
            "Argentina",
            "Brazil",
            "Peru",
            "Venezuela",
            "Great Britain",
            "Iceland",
            "Northern Europe",
            "Southern Europe",
            "Ukraine",
            "Western Europe",
            "Congo",
            "East Africa",
            "Madagascar",
            "North Africa",
            "South Africa",
            "Afghanistan",
            "China",
            "India",
            "Irkutsk",
            "Japan",
            "Kamchatka",
            "Middle East",
            "Mongolia",
            "Siam",
            "Siberia",
            "Ural",
            "Yakutsk",
            "Eastern Australia",
            "Indonesia",
            "New Guinea",
            "Western Australia",
        };

        public static string Get(string partial)
        {
            return Territories.FirstOrDefault(t => t.StartsWith(partial));
        }
    }
    public static class Console2
    {
        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }

}
