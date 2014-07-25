DDD-Risk
========

## Initial Thoughts

Does a player host a game or create a game.

Hosting would suggest that players then join the game where as creating a game would suggest that the data is provided then

Do you invite people or do they just join?

If you invite they have to accept

If they ask to join you have to accept

This can only happen if the game is not already full

Can people leave before the game starts? Can people leave once the game has started?

What is required to start a game? At least 2 players

This is actually pre game rather game, separate boundaries

## Invitation

I should really use a GUID to identify an invitation


#fill: #fff;
#lineWidth: 2

[Lobby
|
gameName: string;
invitedPlayers: List;
joinedPlayers: List
|
Lobby()
InvitePlayer()
AcceptInvitation()
LeaveLobby()
StartGameSetup()
]

[GameSetup
|
gameName: string;
board: Board;
players: List<Player>
|
DecideWhoGoesFirst()
PlaceUnitOnBoard()

]

[Board
|
territories: List<Territory>
]

[Player
|
]

[GameSetup]->[Board]
[<sender> GameSetup]->[Player]

[name]
[<abstract> name]
[<instance> name]
[<note> name]
[<package> name]
[<frame> name]
[<database> name]
[<start> name]
[<end> name]
[<state> name]
[<choice> name]
[<input> name]
[<sender> name]
[<receiver> name]
