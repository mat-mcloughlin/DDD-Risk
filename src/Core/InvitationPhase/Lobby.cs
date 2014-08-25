namespace Core.InvitationPhase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CommonDomain.Core;

    using Core.InvitationPhase.Exceptions;

    public class Lobby : AggregateBase
    {
        const int MinNumberOfPlayers = 2;

        const int MaxNumberOfPlayers = 5;

        readonly Dictionary<Guid, Player> _invitedPlayers;

        readonly Dictionary<Guid, string> _joinedPlayers;

        Guid _gameId;

        string _gameName;

        Host _host;

        public Lobby(Guid lobbyId, Guid gameId, string gameName, Guid hostId, string hostName)
            : this()
        {
            RaiseEvent(new LobbyCreated(lobbyId, gameId, gameName, hostId, hostName));
        }

        private Lobby()
        {
            _invitedPlayers = new Dictionary<Guid, Player>();
            _joinedPlayers = new Dictionary<Guid, string>();
        }

        public void InvitePlayer(Guid playerId, string playerName, Guid invitationToken)
        {
            RaiseEvent(new PlayerInvited(playerId, playerName, invitationToken));
        }

        public void AcceptInvitation(Guid invitationToken)
        {
            CheckInvitationTokenIsValid(invitationToken);
            CheckLobbyStillHasRoom();

            var player = _invitedPlayers[invitationToken];

            RaiseEvent(new InvitationAccepted(Id, player.Id, player.Name, invitationToken));
        }

        public void LeaveLobby(Guid playerId)
        {
            if (_joinedPlayers.ContainsKey(playerId))
            {
                RaiseEvent(new LeftLobby(Id, playerId));
            }
        }

        public void StartGame(Guid setupGameId)
        {
            CheckThereIsTheMinimumNumberOfPlayers();

            var players = _joinedPlayers.Keys.ToList();
            players.Add(_host.Id);

            RaiseEvent(new GameStarted(setupGameId, _gameId, _gameName, players));
        }

        void CheckThereIsTheMinimumNumberOfPlayers()
        {
            if (_joinedPlayers.Count < MinNumberOfPlayers)
            {
                throw new NotEnoughPlayersException();
            }
        }

        void Apply(LobbyCreated e)
        {
            Id = e.LobbyId;
            _gameId = e.GameId;
            _gameName = e.GameName;
            _host = new Host(e.HostId, e.HostName);
        }

        void Apply(PlayerInvited e)
        {
            _invitedPlayers.Add(e.InvitationToken, new Player(e.PlayerId, e.PlayerName));
        }

        void Apply(InvitationAccepted e)
        {
            _joinedPlayers.Add(e.PlayerId, e.PlayerName);
        }

        void Apply(LeftLobby e)
        {
            _joinedPlayers.Remove(e.PlayerId);
        }

        void Apply(GameStarted e)
        {
            // Stop lobby being modified at this point.
        }

        void CheckLobbyStillHasRoom()
        {
            if (_joinedPlayers.Count >= MaxNumberOfPlayers)
            {
                throw new LobbyIsFullException();
            }
        }

        void CheckInvitationTokenIsValid(Guid invitationToken)
        {
            var tokens = _invitedPlayers.Keys;

            if (!tokens.Contains(invitationToken))
            {
                throw new InvalidInvitationTokenException();
            }
        }
    }
}