namespace Core.SetupPhase.Projections
{
    using Console;

    using Core.SetupPhase;
    using Core.SetupPhase.DTO;

    using MongoDB.Driver;

    public class GameSetupStartedProjection : IConsume<GameSetupStarted>
    {
        private readonly MongoDatabase _database;

        public GameSetupStartedProjection(MongoDatabase database)
        {
            _database = database;
        }

        public void Consume(GameSetupStarted e)
        {
            var collection = _database.GetCollection<BoardStateDTO>("BoardStateDTOs");

            var boardStateDTO = new BoardStateDTO { Id = e.GameSetupId };

            foreach (var territory in e.Board.Territories)
            {
                boardStateDTO.Territories.Add(new TerritoryDTO { Name = territory.Key });
            }

            collection.Save(boardStateDTO);
        }
    }
}
