namespace Core.InvitationPhase.Projections
{
    using System.Linq;

    using Console;

    using Core.InvitationPhase.DTO;

    using MongoDB.Driver;

    public class LeftLobbyProjection : IConsume<LeftLobby>
    {
        private readonly MongoDatabase _database;

        public LeftLobbyProjection(MongoDatabase database)
        {
            _database = database;
        }

        public void Consume(LeftLobby e)
        {
            var collection = _database.GetCollection<LobbyDTO>("LobbyDTOs");
            var lobbyDTO = collection.FindOneById(e.LobbyId);
            var playerToRemove = lobbyDTO.Players.SingleOrDefault(p => p.Id == e.PlayerId);

            if (playerToRemove != null)
            {
                lobbyDTO.Players.Remove(playerToRemove);
            }

            collection.Save(lobbyDTO);
        }
    }
}
