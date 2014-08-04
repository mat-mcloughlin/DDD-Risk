The __host__ _decides_ to start a __game__.  
The _knowledge_ is the __lobby__ is created.  
The _provided data_ is the __game name__.
This _decision_ is always available.

The host _decides_ to who to __invite__ to the __lobby__.  
The _provided data_ is the __player__ name.  
The _knowledge_ is a new __invited player__ .  
This _decision_ is available when the __lobby__ is not full.  

The __player__ _decides_ to accept the __invitation__.  
The _available data_ is the __lobby__ isn't full.  
The _provided data_ is the __invitation__.  
The _knowledge_ is a new __joined player__.  
This _decision_ is available when the __player__ has been invited and the game the game isn't full.

The __player__ _decides_ to leave the __lobby__.  
The _provided data_ is the player.  
The _knowledge_ is a __player__ is removed from the game.  
The _decision_ is available when the __player__ is in the __lobby__.

The __host__ _decides_ to __start__ the game.  
The _available data_ is the __joined players__ and the __game name__.  
The _knowledge_ it the game __starts__ with all __players__ in the __lobby__.  
The _decision_ is available when more than 2 but less than 6 players are in the lobby.

The __player__ _decides_ which __territory__ to __occupy__.  
The _available data_ is which __territories__ haven't been __occupied__.  
The _provided data_ is which __territory__ is being __occupied__ by the __infantry unit__.  
The _knowledge_ is a new __infantry unit__ is placed.  
The _decision_ is available when it is the __players__ __turn__ and when there are __territories__ __unoccupied__ and the __game__ has started.

The __player__ _decides_ which __territory__ to __occupy__ with a __neutral unit__.  
The _available data_ is which __territories__ haven't been __occupied__.  
The _provided data_ is which __territory__ the __infantry unit__ is being placed.  
The _knowledge_ is a new __infantry unit__ is placed.  
The _decision_ is available when there are only 2 __players__ in the __game__, when it is the __player__s turn to place a __neutral__ and when there are __territories unoccupied__ and the __game__ has started.

The __player__ _decides_ which __territory__ to __reinforce__.  
The _available data_ is which __territories__ are __occupied__ by them.  
The _provided data_ is which __territory__ to __reinforce__.  
The _knowledge_ is a new __infantry unit__ is placed.  
The _decision_ is available when it is the __players turn__ and they have at least one __unit__ left and the __game__ has started. _*(This happens after the occupation stage in a round robin and then at the start of every subsequent turn)_.

The __player__ _decides_ which __territory__ to __reinforce__ with a __neutral unit__.  
The _available data_ is which __territories__ are __occupied__ by a __neutral unit__.  
The _provided data_ is which territory the unit is being placed.  
The _knowledge_ is a new unit is placed.  
The _decision_ is available when there are only 2 players in the game, when it is the players turn to place a neutral and when there is at least one neutral unit left and the game has started.

The __player__ _decides_ to __exchange__ a __Risk card__ to __draft reinforcements__.  
The _available data_ is which __Risk cards__ they are holding.  
The _provided data_ is which __Risk cards__ they wish to __exchange__.  
The _knowledge_ is how many additional __units__ they __draft__.  
The _decision_ is available when its the start of their __turn__ and they have __Risk cards__ available.

The __player__ _decides_ which __territory__ to __attack__.  
The _available data_ is how many __units__ the __attacking__ __territory__ has and how many __units__ the __defending__ __territory__ has.  
The _provided data_ is how many __units__ the __player__ wishes to __attack__ with (up to three).  
The _knowledge_ is whether it was a __successful or failed attack__ and how many __attacking__ and __defending__ __units__ are left and whether the __territory__ has been __conquered__.  
The _decision_ is available when the __attacking player__ has at least two __units__ in the __attacking territory__, the __territory__ being __attacked__ is an __adjacent territory__, the __attacking territory__ was not __conquered__ this __turn__, the __player__ has placed all available __reinforcements__ and it's still their __turn__.

The __player__ _decides_ how many __units__ to place in the __conquered territory__.  
The _available data_ is how many __units__ are available to move.
The _provided data_ is how many __units__ the __player__ wants to move.  
The _knowledge_ is how many __units__ are left in the __attacking and defending territories__.  
The _decision_ is available when the __player__ has __conquered__ a __territory__ and it's still their turn.

The __player__ _decides_ to __fortify__ a __territory__.  
The _available data_ is how many __units__ the __fortifyiung__ from __territory__ has.  
The _provided data_ is how many __units__ the __player__ wishes to __fortify__ with and which __territory__ they are __fortifying__.  
The _knowledge_ is the number of __units__ left in both the __fortifying__ from __territory__ and the __fortified territory__.  
The _decision_ is available when the two __territories__ are adjacent, they are both __occupied__ by the __player__, and the __player__ has finished __attackin__g and its their __turn__.

The __player__ _decides_ to end their __turn__.  
The _knowledge_ is how many __Risk cards__ they receive and who's __turn__ is next.  
The _decision_ is available when it's the __players turn__ and they have finished __fortifying__.
