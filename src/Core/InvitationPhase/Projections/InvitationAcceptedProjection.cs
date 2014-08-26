namespace Core.InvitationPhase.Projections
{
    using Console;

    using Core.InvitationPhase.DTO;

    using MongoDB.Driver;

    public class InvitationAcceptedProjection : IConsume<InvitationAccepted>
    {
        private readonly MongoDatabase _database;

        public InvitationAcceptedProjection(MongoDatabase database)
        {
            _database = database;
        }

        public void Consume(InvitationAccepted e)
        {
            var collection = _database.GetCollection<LobbyDTO>("LobbyDTOs");
            var lobbyDTO = collection.FindOneById(e.LobbyId);
            lobbyDTO.Players.Add(new PlayerDTO { Id = e.PlayerId, Name = e.PlayerName });
            collection.Save(lobbyDTO);
        }
    }
}
