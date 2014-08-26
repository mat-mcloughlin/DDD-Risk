namespace Core.SetupPhase.Projections
{
    using System.Linq;

    using Console;

    using Core.SetupPhase;
    using Core.SetupPhase.DTO;

    using MongoDB.Driver;

    public class InfantryUnitPlacedProjection : IConsume<InfantryUnitPlaced>
    {
        private readonly MongoDatabase _database;

        public InfantryUnitPlacedProjection(MongoDatabase database)
        {
            _database = database;
        }

        public void Consume(InfantryUnitPlaced e)
        {
            var collection = this._database.GetCollection<BoardStateDTO>("BoardStateDTOs");
            var boardStateDTO = collection.FindOneById(e.GameSetupId);

            var territory = boardStateDTO.Territories.FirstOrDefault(t => t.Name == e.Territory);

            if (territory != null)
            {
                territory.OccupyingPlayerId = e.CurrentPlayerId;
                territory.NumberOfInfantryUnits++;
            }

            collection.Save(boardStateDTO);
        }
    }
}
