namespace Core.GameCreation
{
    public class Lobby
    {
        public Lobby(CreateLobby command)
        {
            this.GameName = command.GameName;
            this.Host = new Host(command.HostId, command.HostName);
        }

        public string GameName { get; private set; }

        public Host Host { get; private set; }
    }
}