namespace Core.GameCreation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Lobby
    {
        private const int MaxNumberOfPlayers = 5;

        public Lobby(CreateLobby command)
            : this()
        {
            this.GameName = command.GameName;
            this.Host = new Host(command.HostId, command.HostName);
        }

        private Lobby()
        {
            this.InvitedPlayers = new Dictionary<Guid, Player>();
            this.JoinedPlayers = new Dictionary<Guid, Player>();
        }

        public string GameName { get; private set; }

        public Host Host { get; private set; }

        public Dictionary<Guid, Player> InvitedPlayers { get; private set; }

        public Dictionary<Guid, Player> JoinedPlayers { get; private set; }

        public void Handle(InvitePlayer command)
        {
            this.InvitedPlayers.Add(command.PlayerId, new Player(command.PlayerName, command.InvitationToken));
        }

        public void Handle(AcceptInvitation command)
        {
            this.CheckInvitationTokenIsValid(command.InvitationToken);
            this.CheckLobbyStillHasRoom();
            
            var player = this.InvitedPlayers.Single(p => p.Value.InvitationToken == command.InvitationToken);
            this.JoinedPlayers.Add(player.Key, player.Value);
        }

        private void CheckLobbyStillHasRoom()
        {
            if (this.JoinedPlayers.Count >= MaxNumberOfPlayers)
            {
                throw new LobbyIsFullException();
            }
        }

        private void CheckInvitationTokenIsValid(Guid invitationToken)
        {
            var tokens = this.InvitedPlayers.Values.Select(p => p.InvitationToken);

            if (!tokens.Contains(invitationToken))
            {
                throw new InvalidInvitationTokenException();
            }
        }
    }
}