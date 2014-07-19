

__mat-mcloughlin.net__  
@Bryan.Watts Looking forward to working on this now
_8:04:33 AM_  

__Bryan.Watts__  
awesome
_8:05:20 AM_  
love something that kick-starts ideas
_8:05:26 AM_  

__mat-mcloughlin.net__  
yeah
_8:05:43 AM_  
wondering whether to use a something pre existing like CD or write my own infra now
_8:06:15 AM_  

__Bryan.Watts__  
cd?
_8:06:31 AM_  

__mat-mcloughlin.net__  
common domain
_8:06:36 AM_  

__Bryan.Watts__  
ah
_8:06:42 AM_  
don't start with someone else's preconceptions
_8:06:49 AM_  

__mat-mcloughlin.net__  
I wrote my own first time round
_8:07:01 AM_  
normally think its the best way to learn how something works
_8:07:19 AM_  

__Bryan.Watts__  
definitely
_8:07:28 AM_  

__mat-mcloughlin.net__  
but then I always think somebody has probably done it better so I'll use theirs ​​
_8:07:43 AM_  

__Bryan.Watts__  
I'd say, in this case that is your core domain, so it's not what you would farm out. it's the value
_8:07:51 AM_  

__mat-mcloughlin.net__  
this is true
_8:08:03 AM_  

__Bryan.Watts__  
man, those other chapters of DDD turned out to be useful ​​
_8:08:40 AM_  
here's a metaphor
_8:08:52 AM_  
there are some plants that propagate by individual pieces having the ability to grow
_8:09:26 AM_  
i.e. some part falls off and can become its own version of that plant
_8:09:41 AM_  
those plants don't have the opportunity to evolve from scratch
_8:10:17 AM_  
they start in a certain state
_8:10:26 AM_  
the alternative is that each generation is imparted the "output" (genes) of the prior generation
_8:11:12 AM_  
but starts from first principles
_8:11:29 AM_  
the point is
_8:11:32 AM_  
if you want a clone, start as a clipping
_8:11:44 AM_  
if you want to evolve your thinking, start from scratch
_8:11:59 AM_  

__mat-mcloughlin.net__  
good analogy
_8:12:09 AM_  
I wonder where this is going to start
_8:12:52 AM_  

__Bryan.Watts__  
evolutionary psychology is good stuff
_8:13:14 AM_  
if you were to sit down to play a game, what is the first decision you would have to make as a user?
_8:13:25 AM_  
new game
_8:14:04 AM_  
what data goes into that?
_8:14:14 AM_  
opponents?
_8:14:19 AM_  
what data is available out in the world, and what data does the user provide?
_8:14:46 AM_  

__mat-mcloughlin.net__  
the first part is game setup. Joining the game
_8:14:59 AM_  

__Bryan.Watts__  
"the game"
_8:15:07 AM_  
my game?
_8:15:08 AM_  
yours?
_8:15:11 AM_  

__mat-mcloughlin.net__  
I'd say the game
_8:15:53 AM_  

__Bryan.Watts__  
when I say game, I mean instance of the board with specific opponents
_8:17:22 AM_  
is that what you mean by game?
_8:17:28 AM_  

__mat-mcloughlin.net__  
...
_8:17:49 AM_  
thinking
_8:17:54 AM_  

__Bryan.Watts__  
I want to make sure you didn't mean game as "the entire app"
_8:1_8:12 AM_  

__mat-mcloughlin.net__  
I didn't think
_8:1_8:17 AM_  
I was already starting to think like that
_8:19:00 AM_  
in my head. Right game is the AR... etc.. etc
_8:19:23 AM_  

__Bryan.Watts__  
haha
_8:19:47 AM_  
so, we have the user decision to start a game
_8:20:27 AM_  
requiring specific opponents and possibly other stuff
_8:20:43 AM_  

__mat-mcloughlin.net__  
would you have that rather than start game
_8:20:58 AM_  
then have people join the game
_8:21:04 AM_  

__Bryan.Watts__  
good question
_8:21:17 AM_  
so now we have a different decision forming
_8:21:49 AM_  
host game
_8:21:51 AM_  

__mat-mcloughlin.net__  
yeah, that sounds better
_8:22:14 AM_  

__Bryan.Watts__  
start will happen eventually
_8:22:24 AM_  
but it's not first
_8:22:27 AM_  
I'm thinking of this as, if I were to draw left-to-right the entire timeline of the history of one of these interactions between users
_8:22:51 AM_  
what is that first point going to be?
_8:23:03 AM_  
so, we want to host a game
_8:23:28 AM_  
what kind of data do we have to provide to do so?
_8:23:37 AM_  
game settings
_8:23:59 AM_  

__mat-mcloughlin.net__  
That depends. Rules are defined unless you play alternate rules so there is nothing to specifiy other than to say your going to play
_8:24:52 AM_  
you wouldn't say how many people are playing as that would come from people joining
_8:25:24 AM_  

__Bryan.Watts__  
perfect
_8:25:29 AM_  

__mat-mcloughlin.net__  
but there is a max number of people
_8:25:38 AM_  

__Bryan.Watts__  
public/private?
_8:25:38 AM_  
implying friends
_8:25:41 AM_  
let's keep it public
_8:25:44 AM_  
ok max number of people
_8:26:03 AM_  
let's say we name the room
_8:26:16 AM_  
Risque
_8:26:21 AM_  
"I make the decision to host the game 'Risque'"
_8:26:53 AM_  
next decision
_8:27:01 AM_  
joining
_8:27:08 AM_  

__mat-mcloughlin.net__  
inviting?
_8:27:12 AM_  

__Bryan.Watts__  
haha was just typing it
_8:27:23 AM_  

__mat-mcloughlin.net__  
lol
_8:27:29 AM_  

__Bryan.Watts__  
what data would I provide when inviting?
_8:27:39 AM_  

__mat-mcloughlin.net__  
well I don't want to start thinking of this as a network game, so i imagine just name
_8:28:10 AM_  

__Bryan.Watts__  
agreed
_8:28:28 AM_  
so you want to invite Bob
_8:28:32 AM_  
"I decide to invite Bob to 'Risque'"
_8:29:02 AM_  
can people discover?
_8:29:19 AM_  
i.e. Sally decides to join the game independently?
_8:29:34 AM_  

__mat-mcloughlin.net__  
then bob has to either accept or decline
_8:29:47 AM_  

__Bryan.Watts__  
ok good, I was going breadth-first
_8:30:06 AM_  

__mat-mcloughlin.net__  
well if sally asks to join
_8:30:09 AM_  
you then need to say yes or no
_8:30:15 AM_  

__Bryan.Watts__  
it's a totally different decision path, you were spot on there
_8:30:32 AM_  
back to Bob
_8:30:39 AM_  
decisions over data ​​
_8:31:02 AM_  
Bob, through mechanisms undefined, observes the invite
_8:31:32 AM_  
his decision is to accept or decline, as you said
_8:31:49 AM_  
"I decide to join 'Risque' thanks to Mat"
_8:32:17 AM_  

__mat-mcloughlin.net__  
(damn we haven't even started the game yet ​​)
_8:32:27 AM_  

__Bryan.Watts__  
it's collaboration man
_8:32:38 AM_  
more complex than we give it credit for
_8:32:47 AM_  
these are the decisions available to everyone involved while setting up the game
_8:33:23 AM_  
the next is to start the game
_8:33:54 AM_  
what kind of issues could we encounter that would invalidate our decision to start?
_8:34:25 AM_  

__mat-mcloughlin.net__  
I'm just writing this down
_8:34:28 AM_  

__Bryan.Watts__  
nobody else wants to play!
_8:34:46 AM_  

__mat-mcloughlin.net__  
got to be at least 2 playes
_8:37:03 AM_  
FYI rules change dependent upon the number of players
_8:37:20 AM_  

__Bryan.Watts__  
is that all they depend on?
_8:37:29 AM_  
i.e. are we missing any switches we might need to flip later?
_8:37:43 AM_  

__mat-mcloughlin.net__  
so if you stick to standard rules that is the only flag I can think of
_8:38:44 AM_  

__Bryan.Watts__  
great
_8:39:11 AM_  
so we can say the decision to start a game is available when the number of plays is at least 2
_8:39:27 AM_  
*players
_8:39:33 AM_  
one last administrative thing
_8:39:51 AM_  
can players leave a game?
_8:40:00 AM_  
and, can they be booted?
_8:40:32 AM_  

__mat-mcloughlin.net__  
they can forfiet
_8:40:33 AM_  

__Bryan.Watts__  
before it starts
_8:40:38 AM_  
we haven't started yet
_8:40:40 AM_  
sorry, regressed a tiny bit
_8:40:46 AM_  
we didn't cover the pre-game decision space
_8:41:08 AM_  
the other decisions, briefly, are "I decide to leave a game before it starts"
_8:41:31 AM_  
"I decide to block another player from this game"
_8:41:55 AM_  
and the last detail
_8:42:09 AM_  
the decision to join a game is available only when the game is not full
_8:42:22 AM_  
*full = players == max players
_8:42:33 AM_  
with me?
_8:42:46 AM_  

__mat-mcloughlin.net__  
yep
_8:42:49 AM_  

__Bryan.Watts__  
now, here's an exercise I probably find more fun than I should
_8:43:07 AM_  
when inviting players, we didn't quite nail down everything
_8:43:21 AM_  
the provided data for that decision is a username
_8:43:52 AM_  
that implies the available data for the decision is the set of usernames
_8:44:05 AM_  
except those already in the game
_8:44:18 AM_  
the decision to invite a user is also available only when the game is not full
_8:45:10 AM_  
therefore, we can summarize
_8:45:19 AM_  

__mat-mcloughlin.net__  
k
_8:45:40 AM_  

__Bryan.Watts__  
The decision to invite a player to a game requires a username, from the set of usernames not already in the game. This decision is available when the game is not full.
_8:46:16 AM_  
what you read there is
_8:46:24 AM_  
command structure, read model, when "enabled"
_8:46:54 AM_  

__mat-mcloughlin.net__  
k
_8:47:01 AM_  

__Bryan.Watts__  
looking back on other decisions
_8:47:24 AM_  
we can say that the decision to start the game requires no data and is available when the game has 2 or more players
_8:47:59 AM_  
the point I'm making, I realize now in a long-winded manner
_8:48:13 AM_  
is that each decision implies the commands, events, and UI
_8:48:43 AM_  
it tells us what we need to see to make the decision
_8:48:52 AM_  
and thus what we need to provide to allow the UI to render so it can provide the decision
_8:49:06 AM_  

__mat-mcloughlin.net__  
yeah
_8:49:24 AM_  
I get that
_8:49:33 AM_  

__Bryan.Watts__  
it also tells us what projections to write ​​
_8:49:39 AM_  

__mat-mcloughlin.net__  
but would you worry about projections at this point?
_8:49:58 AM_  

__Bryan.Watts__  
nope
_8:50:03 AM_  
and good call
_8:50:08 AM_  
really I'm just laying out how I think about commands and what I'm seeing when I say each decision
_8:50:44 AM_  
teach a man to fish and all that
_8:50:50 AM_  
let's think about that timeline again
_8:51:35 AM_  
we now know the points on it are: "host game", "invite Bob", "invite Sally", "accept (Bob)", "accept (Sally)"
_8:52:19 AM_  
but that's not right, is it?
_8:52:36 AM_  
really it's "game hosted", "Bob invited", "Sally invited", etc.
_8:52:48 AM_  

__mat-mcloughlin.net__  
the events yes?
_8:53:03 AM_  

__Bryan.Watts__  
right
_8:53:10 AM_  
we started talking in commands
_8:53:15 AM_  
but a timeline is events
_8:53:18 AM_  
the transition is aggregates
_8:53:26 AM_  
so that's the next step
_8:53:30 AM_  
transaction boundaries
_8:53:33 AM_  
hosting a game introduces a new boundary
_8:53:50 AM_  
the gut reaction is to say "well right, a game is a boundary because it's the natural containing thing of all of this"
_8:54:32 AM_  

__mat-mcloughlin.net__  
thats what I was thinking
_8:54:45 AM_  

__Bryan.Watts__  
me too
_8:54:52 AM_  
I started thinking about what I was thinking
_8:54:57 AM_  
so this is off the cuff
_8:55:03 AM_  
but hear me out
_8:55:05 AM_  

__mat-mcloughlin.net__  
go for it
_8:55:12 AM_  

__Bryan.Watts__  
containment is a spatial concept
_8:55:18 AM_  
transaction boundaries are temporal concepts
_8:55:24 AM_  
that's why we mistake entities for aggregates
_8:55:39 AM_  

__mat-mcloughlin.net__  
ok
_8:55:56 AM_  

__Bryan.Watts__  
so I'm not going to immediately jump to game aggregate
_8:56:06 AM_  

__mat-mcloughlin.net__  
so where's your thinking going?
_8:56:10 AM_  

__Bryan.Watts__  
instead, let's think about those decisions
_8:56:12 AM_  
and how they affect each others' data
_8:56:23 AM_  
host game: creates a new boundary
_8:57:08 AM_  
invite user: obviously affected by host game because it is part of the provided data
_8:57:39 AM_  
we have to provide a game with that decision, so invite user is dependent on host game
_8:58:10 AM_  
they belong in the same boundary
_8:58:15 AM_  
next, invite user
_8:58:34 AM_  
we provide the username
_8:59:10 AM_  
so it doesn't require any other data besides the game
_8:59:30 AM_  
so it also belongs in that boundary
_8:59:38 AM_  
how about accept invite
_9:00:00 AM_  
it doesn't require any data, but it does affect the available data for invite user
_9:00:18 AM_  
so it belongs in the same boundary
_9:00:30 AM_  
start game has an issue if there are not at least 2 players, so all the invites affect its data, and it belongs in the same boundary
_9:01:19 AM_  

__mat-mcloughlin.net__  
...
_9:01:27 AM_  

__Bryan.Watts__  
we have absolutely determined that the set of commands all affect the same boundary
_9:01:38 AM_  

__mat-mcloughlin.net__  
carry on... but this is still leading me to think that game is the boundary
_9:01:50 AM_  

__Bryan.Watts__  
:itsatrap:
_9:02:05 AM_  
dAM_  n
_9:02:06 AM_  
:ackbar:
_9:02:11 AM_  
ah well
_9:02:15 AM_  

__mat-mcloughlin.net__  
lol
_9:02:16 AM_  
however
_9:02:21 AM_  
is there a distinction between pre game and game?
_9:02:46 AM_  

__Bryan.Watts__  
nailed it
_9:02:52 AM_  
I was working up to making the implicit explicit
_9:02:58 AM_  
by showing that every decision after start game is not in the same boundary
_9:03:07 AM_  

__mat-mcloughlin.net__  
ha, this is good ​​
_9:03:55 AM_  

__Bryan.Watts__  
very
_9:04:17 AM_  
so what do you think of Lobby? or Room?
_9:04:26 AM_  

__mat-mcloughlin.net__  
...
_9:04:41 AM_  
they feel linked to network gaming
_9:05:01 AM_  
I've been thinking of this as more of people sat around a table or something. But that might not be a bad way to go
_9:05:23 AM_  

__Bryan.Watts__  
well, I play Titanfall constantly so I have seen that distinction become less pronounced ​​
_9:05:32 AM_  

__mat-mcloughlin.net__  
lobby might not be a bad way to go
_9:05:54 AM_  

__Bryan.Watts__  
yeah it's just people getting together to coordinate
_9:06:05 AM_  
doesn't have to imply all the other social crap that usually comes with
_9:06:14 AM_  
I'm thinking Hearthstone or Scrolls or something, where it's a single-player experience over the network
_9:06:44 AM_  

__mat-mcloughlin.net__  
Lobby suggests somewhere you wait. Room might be better
_9:07:06 AM_  

__Bryan.Watts__  
er, feels like single-player
_9:07:06 AM_  
yeah
_9:07:14 AM_  
pre-game works too
_9:07:17 AM_  
I just didn't want to make the classic cart/order mistake ​​
_9:07:26 AM_  

__mat-mcloughlin.net__  
​yeah
_9:07:35 AM_  

__Bryan.Watts__  
one more thing to point out
_9:07:59 AM_  
we haven't talked for very long, and we've already nailed down basically everything we would need to implement this in any tech stack
_9:08:19 AM_  
(the lobby part)
_9:08:40 AM_  

__mat-mcloughlin.net__  
yep
_9:09:09 AM_  

__Bryan.Watts__  
I just realized I framed you as a client
_9:09:52 AM_  
ha
_9:09:52 AM_  

__mat-mcloughlin.net__  
lol
_9:10:02 AM_  
You've done this too much that its become engrained obviously
_9:10:29 AM_  
​​
_9:10:31 AM_  

__Bryan.Watts__  
haha
_9:11:05 AM_  
I did my time in consulting...I'm doing product now, but I bet I could go back and kill it
_9:11:19 AM_  
not that I would ​​
_9:11:24 AM_  
this is going to sound insane, and I know it
_9:11:33 AM_  
but the trajectory of my personal project solves consulting on an abstract level
_9:12:19 AM_  
it wasn't the goal
_9:12:31 AM_  
it's a knowledge work engine
_9:12:38 AM_  
it just so happens that a lot of consulting is just collecting and chewing data
_9:13:04 AM_  

__mat-mcloughlin.net__  
yup
_9:14:17 AM_  
this has been good. Think I've got something to start on
_9:14:47 AM_  

__Bryan.Watts__  
definitely
_9:15:23 AM_  
I think it's time for me to finally go to bed
_9:15:32 AM_  
been procrastinating on that ​​
_9:15:38 AM_  

__mat-mcloughlin.net__  
lol
_9:16:11 AM_  
before you finally go, you had one more point?
_9:16:29 AM_  

__Bryan.Watts__  
did I? ha
_9:16:44 AM_  
oh
_9:16:53 AM_  
it was the efficient nature of this design orientation
_9:17:04 AM_  
you would be amazed how much talk in meetings could be just, freakin eliminated
_9:17:31 AM_  
people talking about this data and that data and what about when someone wants to do this with that data
_9:17:53 AM_  
you get on those crazy rabbit holes like the one we almost went on, about game discovery
_9:18:23 AM_  
because we happened to be talking about data that would also be relevant in that decision
_9:18:37 AM_  
looking from the decisions' point of view, these things are fairly unambiguous
_9:18:52 AM_  
so yeah
_9:18:53 AM_  
that
_9:18:54 AM_  

__mat-mcloughlin.net__  
​thanks for this man
_9:20:19 AM_  
appreciate the time
_9:20:24 AM_  
*I
_9:20:27 AM_  

__Bryan.Watts__  
yeah no problem
_9:20:33 AM_  
always looking to sharpen the sword
_9:20:39 AM_  
I find that blogging is very difficult because of the static audience
_9:20:49 AM_  
I like interaction
_9:20:51 AM_  

__mat-mcloughlin.net__  
Yeah
_9:20:59 AM_  
I agree
_9:21:02 AM_  
Although I like to take notes after a conversation like this
_9:21:13 AM_  
So I should probably blog them ​​
_9:21:19 AM_  
FYI https://github.com/mat-mcloughlin/DDD-Risk
_9:21:23 AM_  

__Bryan.Watts__  
awesome
_9:21:51 AM_  
watched
_9:21:52 AM_  

__mat-mcloughlin.net__  
Right. I'm gonna write my first test ​​
_9:22:13 AM_  

__Bryan.Watts__  
nice
_9:22:26 AM_  

__mat-mcloughlin.net__  
And I think you're right
_9:22:35 AM_  
I'm going to try and let the arch flow out of this
_9:22:46 AM_  

__Bryan.Watts__  
(sent to @z3roshot, my cousin)
_9:22:54 AM_  
definitely
_9:23:01 AM_  
I think it will come organically
_9:23:07 AM_  
this can all be done with simple classes
_9:23:14 AM_  
it's really how spread-out and how persistent you want it to be that makes the difference
_9:23:26 AM_  
otherwise command = method and query = property
_9:23:35 AM_  
that's the easiest domain in the world
_9:23:39 AM_  

__mat-mcloughlin.net__  
well I'll just start by raising the events and see where it goes from there
_9:24:24 AM_  

__Bryan.Watts__  
are you thinking event classes?
_9:24:44 AM_  
or an event mechanism?
_9:24:51 AM_  

__mat-mcloughlin.net__  
I'm not sure I understand
_9:25:17 AM_  

__Bryan.Watts__  
hehe sorry
_9:25:26 AM_  
there are 3 flavors of events
_9:25:33 AM_  
.NET raw
_9:25:37 AM_  
IObservable<>
_9:25:41 AM_  

__mat-mcloughlin.net__  
ah
_9:25:44 AM_  
ok
_9:25:46 AM_  

__Bryan.Watts__  
each event gets its own class
_9:25:46 AM_  
so what I'm wondering is, when you publish
_9:25:53 AM_  
are you publishing new gameStarted
_9:26:01 AM_  
or doing something like "_gameStarted.OnNext(...)"
_9:26:12 AM_  
I guess I am wondering what you meant by "raising the events" ​​
_9:26:22 AM_  

__mat-mcloughlin.net__  
gameStarted
_9:26:31 AM_  

__Bryan.Watts__  
sweet
_9:26:39 AM_  
corresponding commands
_9:26:44 AM_  

__mat-mcloughlin.net__  
yup
_9:26:49 AM_  

__Bryan.Watts__  
you don't even need aggregates, you can do everything with just those ​​
_9:26:56 AM_  
get those rules right later haha
_9:27:01 AM_  

__mat-mcloughlin.net__  
Right
_9:27:22 AM_  
I'll make a start and you can rip it to shreds at your pleasure ​​
_9:27:38 AM_  

__Bryan.Watts__  
hahahaha
_9:27:49 AM_  

__mat-mcloughlin.net__  
file => new project
_9:27:51 AM_  

__Bryan.Watts__  
you have no idea what you invited yourself into
_9:27:55 AM_  

__mat-mcloughlin.net__  
lol
_9:28:02 AM_  