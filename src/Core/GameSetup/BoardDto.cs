namespace Core.GameSetup
{
    using System.Collections.Generic;
    using System.Linq;

    public class BoardDto
    {
        public BoardDto(IDictionary<string, TerritoryDto> territories)
        {
            this.Territories = territories;
        }

        public IDictionary<string, TerritoryDto> Territories { get; private set; }

        public static explicit operator Board(BoardDto boardDto)
        {
            var territories = boardDto.Territories
                .ToDictionary(
                    territoryDto => 
                    territoryDto.Key, 
                    territoryDto => new Territory(territoryDto.Value.NumberOfInfantry, territoryDto.Value.OccupyingPlayerId));

            return new Board(territories);
        }
    }
}