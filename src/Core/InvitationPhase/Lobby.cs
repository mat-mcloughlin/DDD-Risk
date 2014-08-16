namespace Core.InvitationPhase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Core.Infrastructure;

    public class Lobby : Topic
    {
        private const int MaxNumberOfPlayers = 5;

        private readonly Dictionary<Guid, Player> invitedPlayers;

        private readonly Dictionary<Guid, Player> joinedPlayers;

        private string gameName;

        private Host host;

        public Lobby(CreateLobby command)
            : this()
        {
            this.Raise(new LobbyCreated(command.GameName, command.HostId, command.HostName));
        }

        private Lobby()
        {
            this.invitedPlayers = new Dictionary<Guid, Player>();
            this.joinedPlayers = new Dictionary<Guid, Player>();
        }

        public void Handle(InvitePlayer command)
        {
            this.Raise(new PlayerInvited(command.PlayerId, command.PlayerName, command.InvitationToken));
        }

        public void Handle(AcceptInvitation command)
        {
            this.CheckInvitationTokenIsValid(command.InvitationToken);
            this.CheckLobbyStillHasRoom();

            this.Raise(new InvitationAccepted(command.InvitationToken));
        }

        public void Handle(LeaveLobby command)
        {
            if (this.joinedPlayers.ContainsKey(command.PlayerId))
            {
                this.Raise(new LeftLobby(command.PlayerId));
            }
        }

        private void When(LobbyCreated @event)
        {
            this.gameName = @event.GameName;
            this.host = new Host(@event.HostId, @event.HostName);
        }

        private void When(PlayerInvited @event)
        {
            this.invitedPlayers.Add(@event.PlayerId, new Player(@event.PlayerName, @event.InvitationToken));
        }

        private void When(InvitationAccepted @event)
        {
            var player = this.invitedPlayers.Single(p => p.Value.InvitationToken == @event.InvitationToken);
            this.joinedPlayers.Add(player.Key, player.Value);
        }

        private void When(LeftLobby @event)
        {
            this.joinedPlayers.Remove(@event.PlayerId);
        }

        private void CheckLobbyStillHasRoom()
        {
            if (this.joinedPlayers.Count >= MaxNumberOfPlayers)
            {
                throw new LobbyIsFullException();
            }
        }

        private void CheckInvitationTokenIsValid(Guid invitationToken)
        {
            var tokens = this.invitedPlayers.Values.Select(p => p.InvitationToken);

            if (!tokens.Contains(invitationToken))
            {
                throw new InvalidInvitationTokenException();
            }
        }
    }
}