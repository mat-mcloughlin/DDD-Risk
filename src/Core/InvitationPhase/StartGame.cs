namespace Core.InvitationPhase
{
    using System;

    public class StartGame
    {
        public StartGame(Guid lobbyId, Guid setupGameId)
        {
            LobbyId = lobbyId;
            SetupGameId = setupGameId;
        }

        public Guid LobbyId { get; private set; }

        public Guid SetupGameId { get; private set; }
    }
}