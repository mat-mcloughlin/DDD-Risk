namespace Core.InvitationPhase
{
    using System;

    public class StartGame
    {
        public StartGame(Guid lobbyId)
        {
            LobbyId = lobbyId;
        }

        public Guid LobbyId { get; set; }
    }
}