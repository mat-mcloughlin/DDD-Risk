namespace Core.Facts.InvitationPhase
{
    using System;
    using System.Collections.Generic;

    using Core.InvitationPhase;

    using Xbehave;

    using Xunit;
    using Xunit.Should;

    public class InvitingAndAcceptingInvitations
    {
        [Scenario]
        [Example("Mat")]
        [Example("Bryan")]
        void Host_can_invite_player_to_lobby(string playerName, Guid playerId, Guid invitationToken, Lobby lobby)
        {
            "Given a lobby"
                .Given(() => lobby = new Lobby(Guid.NewGuid(), Guid.NewGuid(), "gameName", Guid.NewGuid(), "hostName"));

            "When we invite a player"
                .When(() =>
                    {
                        playerId = new Guid("8e17de3f-7833-47a6-8f92-cf220cf953e2");
                        invitationToken = new Guid("25e4349b-0f0a-479b-a7c7-78ebfb2ada00");
                        lobby.InvitePlayer(playerId, playerName, invitationToken);
                    });

            "A player should be invited to the list of invited players"
                .Then(() =>
                    {
                        var @event = lobby.LastEvent<PlayerInvited>();
                        @event.PlayerId.ShouldBe(playerId);
                        @event.PlayerName.ShouldBe(playerName);
                        @event.InvitationToken.ShouldBe(invitationToken);
                    });
        }

        [Scenario]
        [Example("Mat")]
        [Example("Bryan")]
        void Player_can_accept_invitation_to_lobby(string playerName, Guid invitationToken, Lobby lobby)
        {
            "Given a lobby"
                .Given(() => lobby = new Lobby(Guid.NewGuid(), Guid.NewGuid(), "gameName", Guid.NewGuid(), "hostName"));

            "And an invited player"
                .And(() =>
                    {
                        var playerId = new Guid("8e17de3f-7833-47a6-8f92-cf220cf953e2");
                        invitationToken = new Guid("25e4349b-0f0a-479b-a7c7-78ebfb2ada00");
                        lobby.InvitePlayer(playerId, playerName, invitationToken);
                    });

            "When the player accepts the invitation"
                .When(() => lobby.AcceptInvitation(invitationToken));

            "A player should be added to the list of joined players"
                .Then(() =>
                    {
                        var @event = lobby.LastEvent<InvitationAccepted>();
                        @event.InvitationToken.ShouldBe(invitationToken);
                    });
        }

        [Scenario]
        [Example("Mat")]
        void Player_cannot_accept_invitation_to_lobby_as_token_is_invalid(string playerName, Guid invitationToken, Lobby lobby)
        {
            "Given a lobby"
                .Given(() => lobby = new Lobby(Guid.NewGuid(), Guid.NewGuid(), "gameName", Guid.NewGuid(), "hostName"));

            "And an invited player"
                .And(() =>
                    {
                        var playerId = new Guid("8e17de3f-7833-47a6-8f92-cf220cf953e2");
                        invitationToken = new Guid("25e4349b-0f0a-479b-a7c7-78ebfb2ada00");
                        lobby.InvitePlayer(playerId, playerName, invitationToken);
                    });

            "When the player accepts the invitation and exception should throw"
                .When(() =>
                    {
                        var invalidInvitationToken = new Guid("7ad2e1e3-21f3-47df-9246-5a5faa1fdea4");
                        Assert.Throws<InvalidInvitationTokenException>(() => lobby.AcceptInvitation(invalidInvitationToken));
                    });
        }

        [Scenario]
        void Player_cannot_accept_invitation_as_lobby_is_full(Lobby lobby)
        {
            var invitationTokens = new List<Guid>();

            "Given a lobby"
                .Given(() => lobby = new Lobby(Guid.NewGuid(), Guid.NewGuid(), "gameName", Guid.NewGuid(), "hostName"));

            "And and 6 invited player"
                .And(() =>
                    {
                        for (var i = 0; i < 6; i++)
                        {
                            var playerId = Guid.NewGuid();
                            var invitationToken = Guid.NewGuid();
                            var playerName = "playerName";

                            invitationTokens.Add(invitationToken);
                            lobby.InvitePlayer(playerId, playerName, invitationToken);
                        }
                    });

            "And has 5 accepted invitations"
                .And(() =>
                    {
                        for (var i = 0; i < 5; i++)
                        {
                            lobby.AcceptInvitation(invitationTokens[i]);
                        }
                    });

            "When another player accepts the invitation a lobby full exception should throw"
                .When(() => Assert.Throws<LobbyIsFullException>(() => lobby.AcceptInvitation(invitationTokens[5])));
        }

        [Scenario]
        void Player_can_leave_the_lobby_after_accepting_invitation(Lobby lobby)
        {
            var invitationToken = Guid.NewGuid();
            var playerId = Guid.NewGuid();

            "Given a lobby"
                .Given(() => lobby = new Lobby(Guid.NewGuid(), Guid.NewGuid(), "gameName", Guid.NewGuid(), "hostName"));

            "And a player who has been invited"
                .And(() =>
                    {
                        var playerName = "playerName";
                        lobby.InvitePlayer(playerId, playerName, invitationToken);
                    });

            "And who accepts"
                .And(() => lobby.AcceptInvitation(invitationToken));

            "When they leave the lobby"
                .When(() => lobby.LeaveLobby(playerId));

            "Then a left lobby event should be raised"
                .Then(() =>
                    {
                        var @event = lobby.LastEvent<LeftLobby>();
                        @event.PlayerId.ShouldBe(playerId);
                    });
        }
    }
}
