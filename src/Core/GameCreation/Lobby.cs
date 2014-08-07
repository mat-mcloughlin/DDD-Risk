namespace Core.GameCreation
{
    using System;
    using System.Collections.Generic;

    public class Lobby
    {
        public Lobby(CreateLobby command)
            : this()
        {
            this.GameName = command.GameName;
            this.Host = new Host(command.HostId, command.HostName);
        }

        private Lobby()
        {
            this.InvitedPlayers = new Dictionary<Guid, Player>();
        }

        public string GameName { get; private set; }

        public Host Host { get; private set; }

        public Dictionary<Guid, Player> InvitedPlayers { get; set; }

        public void Handle(InvitePlayer command)
        {
            this.InvitedPlayers.Add(command.PlayerId, new Player(command.PlayerName));
        }
    }
}