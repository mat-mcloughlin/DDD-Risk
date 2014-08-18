namespace Core.GameSetup
{
    using System.Collections.Generic;

    public class StateOfTheBoardDto
    {
        public StateOfTheBoardDto(IDictionary<string, StateOfTheTerritoryDto> territories)
        {
            this.Territories = territories;
        }

        public IDictionary<string, StateOfTheTerritoryDto> Territories { get; private set; }

        public static explicit operator StateOfTheBoard(StateOfTheBoardDto stateOfTheBoardDto)
        {
            var territories = new Dictionary<string, StateOfTheTerritory>();
            foreach (var stateOfTheTerritoryDto in stateOfTheBoardDto.Territories)
            {
                territories.Add(stateOfTheTerritoryDto.Key, new StateOfTheTerritory(stateOfTheTerritoryDto.Value.NumberOfOccupyingInfantryUnits, stateOfTheTerritoryDto.Value.OwningPlayerId));
            }

            return new StateOfTheBoard(territories);
        }
    }
}