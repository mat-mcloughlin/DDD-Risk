The host __decides__ to start a game.  
The __knowledge__ is the lobby is created.  
The __provided data__ is the game name. 
This __decision__ is always available.

The host __decides__ to who to invite to the lobby.  
The __knowledge__ is a new player is invited.  
The __provided data__ is the player name.  
This __decision__ is available when the lobby is not full.  

The player __decides__ to accept the invitation.  
The __available data__ is the lobby isn't full.  
The __knowledge__ is a new player is added to the game.  
The __provided data__ is the invitation.  
This __decision__ is available when the player has been invited and the game the game isn't full.

The player __decides__ to leave the lobby.  
The __knowledge__ is a player is removed from the game.  
The __provided data__ is the player.  
The __decision__ is available when the player is in the lobby. 

The host __decides__ to start the game.  
The __available data__ is the joined players and the game name.  
The __knowledge__ it the game starts with all players in the lobby.  
The __decision__ is available when more than 2 but less than 6 players are in the lobby.

The player __decides__ which territory to occupy.  
The __available data__ is which territories haven't been occupied.  
The __provided data__ is which territory the unit is being placed.  
The __knowledge__ is a new unit is placed.  
The __decision__ is available when it is the players turn and when there are territories unoccupied and the game has started.

The player decieds which territory to occupy with a neutral unit.  
The __available data__ is which territories haven't been occupied.  
The __provided data__ is which territory the unit is being placed.  
The __knowledge__ is a new unit is placed.  
The __decision__ is available when there are only 2 players in the game, when it is the players turn to place a neutral and when there are territories unoccupied and the game has started.

The player __decides__ which territory to reinforce.  
The __available data__ is which territories are occupied by them.  
The __provided data__ is which territory to reinforce.  
The __knowledge__ is a new unit is placed.  
The __decision__ is available when it is the players turn and they have at least one unit left and the game has started. (This happens after the occupation stage in a round robin and then at the start of every subsequent turn).

The player __decides__ which territory to reinforce with a neutral unit.  
The __available data__ is which territories are occupied by a neutral unit.  
The __provided data__ is which territory the unit is being placed.  
The __knowledge__ is a new unit is placed.  
The __decision__ is available when there are only 2 players in the game, when it is the players turn to place a neutral and when there is at least one neutral unit left and the game has started.

The player __decides__ to convert a risk card into reinforcements.  
The __available data__ is which risk cards they are holding.  
The __provided data__ is which risk cards they wish to convert.  
The __knowledge__ is how many additional units they receive.  
The __decision__ is available when its the start of their turn and they have risk cards available.

The player __decides__ which territory to attack.  
The __available data__ is how many units the attacking country has and how many units the defending unit has.  
The __provided data__ is how many units the player wishes to attack with (up to three).  
The __knowledge__ is whether the attack was successful and how many attacking and defending units are left and whether the territory has been conquered.  
The __decision__ is available when the attacking player has at least two units in the attacking country, the attacking, the country being attack is adjacent to the attacking country, the attacking country was not conquered this turn, the player has placed all available reinforcements and it's still their turn.

The player __decides__ how many units to place in the conquered territory.  
The __available data__ is how many units are available to move. 
The __provided data__ is how many units the player wants to move.  
The __knowledge__ is how many units are left in each territory.  
The __decision__ is available when the player has conquered a territory and it's still their turn.

The player __decides__ to fortify a territory.  
The __available data__ is how many units the reinforcing from territory has.  
The __provided data__ is how many units the player wishes to reinforce with and where they want to reinforce.  
The __knowledge__ is the number of units left in both the reinforced from territory and the reinforced territory.  
The __decision__ is available when the two territories are adjacent, they are both occupied by the player, the reinforcing units have not already been moved, the player has finished attacking and its their turn.

The player __decides__ to end their turn.  
The __knowledge__ is how many risk cards they receive and who's turn is next.  
The __decision__ is available when it's the players turn and they have placed all available reinforcements.
