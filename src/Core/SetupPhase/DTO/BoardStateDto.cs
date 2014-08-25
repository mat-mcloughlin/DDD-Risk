namespace Core.SetupPhase.DTO
{
    using System;
    using System.Collections.Generic;

    public class BoardStateDTO
    {
        public BoardStateDTO()
        {
            this.Territories = new List<TerritoryDTO>();
        }

        public Guid Id { get; set; }

        public IList<TerritoryDTO> Territories { get; set; }
    }
}