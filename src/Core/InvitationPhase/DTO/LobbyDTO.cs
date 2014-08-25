namespace Core.InvitationPhase.DTO
{
    using System;
    using System.Collections.Generic;

    public class LobbyDTO
    {
        public LobbyDTO()
        {
            Players = new List<PlayerDTO>();
        }

        public Guid Id { get; set; }

        public Guid GameId { get; set; }

        public string GameName { get; set; }

        public Guid HostId { get; set; }

        public string HostName { get; set; }

        public IList<PlayerDTO> Players { get; set; }
    }
}