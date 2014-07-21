namespace Risk.Core
{
    using System;
    using System.Collections.Generic;

    public class Lobby
    {
        private const int MinNumberOfPlayers = 2;

        private const int MaxNumberOfPlayers = 6;

        public Lobby(string gameName)
            : this()
        {
            this.GameName = gameName;
        }

        private Lobby()
        {
            this.InvitedPlayers = new Dictionary<Guid, string>();
            this.JoinedPlayers = new Dictionary<Guid, string>();
        }

        public string GameName { get; private set; }

        public IDictionary<Guid, string> InvitedPlayers { get; private set; }

        public IDictionary<Guid, string> JoinedPlayers { get; private set; }

        public void InvitePlayer(string playerName, Guid invitationToken)
        {
            this.InvitedPlayers.Add(invitationToken, playerName);
        }

        public void AcceptInvitation(Guid playerId, string playerName, Guid invitationToken)
        {
            this.CheckMaxNumberOfPlayersHasntBeenExceded();

            this.CheckInvitationTokenIsValid(invitationToken);

            this.JoinedPlayers.Add(playerId, playerName);
        }

        public void LeaveGame(Guid playerId)
        {
            this.JoinedPlayers.Remove(playerId);
        }

        public void StartGame()
        {
            this.CheckMinimumNumberOfPlayersHaveJoined();
        }

        private void CheckMinimumNumberOfPlayersHaveJoined()
        {
            if (this.JoinedPlayers.Count < MinNumberOfPlayers)
            {
                throw new NotEnoughPlayersException();
            }
        }

        private void CheckInvitationTokenIsValid(Guid invitationToken)
        {
            if (!this.InvitedPlayers.ContainsKey(invitationToken))
            {
                throw new InvalidInvitationToken();
            }
        }
        
        private void CheckMaxNumberOfPlayersHasntBeenExceded()
        {
            if (this.JoinedPlayers.Count >= MaxNumberOfPlayers)
            {
                throw new TooManyPlayersException();
            }
        }
    }
}