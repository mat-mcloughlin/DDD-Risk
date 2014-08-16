namespace Core.InvitationPhase
{
    using System;

    public class CreateLobby
    {
        public CreateLobby(string gameName, Guid hostId, string hostName)
        {
            this.GameName = gameName;
            this.HostId = hostId;
            this.HostName = hostName;
        }

        public string GameName { get; private set; }

        public Guid HostId { get; private set; }

        public string HostName { get; private set; }
    }
}