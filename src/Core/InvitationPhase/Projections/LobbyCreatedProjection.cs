namespace Core.InvitationPhase.Projections
{
    using Console;

    using Core.InvitationPhase.DTO;

    using MongoDB.Driver;

    public class LobbyCreatedProjection : IConsume<LobbyCreated>
    {
        private readonly MongoDatabase _database;

        public LobbyCreatedProjection(MongoDatabase database)
        {
            _database = database;
        }

        public void Consume(LobbyCreated e)
        {
            var collection = _database.GetCollection<LobbyDTO>("LobbyDTOs");

            var lobbyDTO = new LobbyDTO
            {
                Id = e.LobbyId,
                GameId = e.GameId,
                GameName = e.GameName,
                HostId = e.HostId,
                HostName = e.HostName
            };

            collection.Save(lobbyDTO);
        }
    }
}
