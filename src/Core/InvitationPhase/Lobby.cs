namespace Core.InvitationPhase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CommonDomain.Core;

    public class Lobby : AggregateBase
    {
        const int MaxNumberOfPlayers = 5;

        readonly Dictionary<Guid, Player> _invitedPlayers;

        readonly Dictionary<Guid, Player> _joinedPlayers;

        Guid _gameId;

        string _gameName;

        KeyValuePair<Guid, string> _host;

        public Lobby(Guid lobbyId, Guid gameId, string gameName, Guid hostId, string hostName)
            : this()
        {
            RaiseEvent(new LobbyCreated(lobbyId, gameId, gameName, hostId, hostName));
        }

        private Lobby()
        {
            _invitedPlayers = new Dictionary<Guid, Player>();
            _joinedPlayers = new Dictionary<Guid, Player>();
        }

        public void InvitePlayer(Guid playerId, string playerName, Guid invitationToken)
        {
            RaiseEvent(new PlayerInvited(playerId, playerName, invitationToken));
        }

        public void AcceptInvitation(Guid invitationToken)
        {
            CheckInvitationTokenIsValid(invitationToken);
            CheckLobbyStillHasRoom();

            RaiseEvent(new InvitationAccepted(invitationToken));
        }

        public void LeaveLobby(Guid playerId)
        {
            if (_joinedPlayers.ContainsKey(playerId))
            {
                RaiseEvent(new LeftLobby(playerId));
            }
        }

        public void StartGame()
        {
            // Make sure min number of players joined (3)
            var players = _joinedPlayers.Keys.ToList();
            players.Add(_host.Key);
            RaiseEvent(new GameStarted(_gameId, _gameName, _joinedPlayers.Keys.ToList()));
        }

        void Apply(LobbyCreated e)
        {
            Id = e.LobbyId;
            _gameId = e.GameId;
            _gameName = e.GameName;
            _host = new KeyValuePair<Guid, string>(e.HostId, e.HostName);
        }

        void Apply(PlayerInvited e)
        {
            _invitedPlayers.Add(e.PlayerId, new Player(e.PlayerName, e.InvitationToken));
        }

        void Apply(InvitationAccepted e)
        {
            var player = _invitedPlayers.Single(p => p.Value.InvitationToken == e.InvitationToken);
            _joinedPlayers.Add(player.Key, player.Value);
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
            var tokens = _invitedPlayers.Values.Select(p => p.InvitationToken);

            if (!tokens.Contains(invitationToken))
            {
                throw new InvalidInvitationTokenException();
            }
        }
    }
}