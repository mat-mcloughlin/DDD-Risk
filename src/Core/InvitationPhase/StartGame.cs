namespace Core.InvitationPhase
{
    using System;

    public class StartGame
    {
        public StartGame(Guid lobbyId)
        {
            this.LobbyId = lobbyId;
        }

        public Guid LobbyId { get; set; }
    }
}