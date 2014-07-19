
mat-mcloughlin.net
@Bryan.Watts Looking forward to working on this now
8:04:33 AM
__Bryan.Watts__
awesome
8:05:20 AM
love something that kick-starts ideas
8:05:26 AM
__mat-mcloughlin.net__
yeah
8:05:43 AM
wondering whether to use a something pre existing like CD or write my own infra now
8:06:15 AM
__Bryan.Watts__
cd?
8:06:31 AM
__mat-mcloughlin.net__
common domain
8:06:36 AM
__Bryan.Watts__
ah
8:06:42 AM
don't start with someone else's preconceptions
8:06:49 AM
​​
8:06:52 AM
__mat-mcloughlin.net__
​​
8:06:54 AM
I wrote my own first time round
8:07:01 AM
normally think its the best way to learn how something works
8:07:19 AM
__Bryan.Watts__
definitely
8:07:28 AM
__mat-mcloughlin.net__
but then I always think somebody has probably done it better so I'll use theirs ​​
8:07:43 AM
__Bryan.Watts__
I'd say, in this case that is your core domain, so it's not what you would farm out. it's the value
8:07:51 AM
__mat-mcloughlin.net__
this is true
8:08:03 AM
__Bryan.Watts__
man, those other chapters of DDD turned out to be useful ​​
8:08:40 AM
here's a metaphor
8:08:52 AM
there are some plants that propagate by individual pieces having the ability to grow
8:09:26 AM
i.e. some part falls off and can become its own version of that plant
8:09:41 AM
those plants don't have the opportunity to evolve from scratch
8:10:17 AM
they start in a certain state
8:10:26 AM
the alternative is that each generation is imparted the "output" (genes) of the prior generation
8:11:12 AM
but starts from first principles
8:11:29 AM
the point is
8:11:32 AM
if you want a clone, start as a clipping
8:11:44 AM
if you want to evolve your thinking, start from scratch
8:11:59 AM
__mat-mcloughlin.net__
good analogy
8:12:09 AM
I wonder where this is going to start
8:12:52 AM
__Bryan.Watts__
evolutionary psychology is good stuff
8:13:14 AM
if you were to sit down to play a game, what is the first decision you would have to make as a user?
8:13:25 AM
new game
8:14:04 AM
what data goes into that?
8:14:14 AM
opponents?
8:14:19 AM
what data is available out in the world, and what data does the user provide?
8:14:46 AM
__mat-mcloughlin.net__
the first part is game setup. Joining the game
8:14:59 AM
__Bryan.Watts__
"the game"
8:15:07 AM
my game?
8:15:08 AM
yours?
8:15:11 AM
__mat-mcloughlin.net__
I'd say the game
8:15:53 AM
__Bryan.Watts__
when I say game, I mean instance of the board with specific opponents
8:17:22 AM
is that what you mean by game?
8:17:28 AM
__mat-mcloughlin.net__
...
8:17:49 AM
thinking
8:17:54 AM
__Bryan.Watts__
I want to make sure you didn't mean game as "the entire app"
8:18:12 AM
__mat-mcloughlin.net__
I didn't think
8:18:17 AM
I was already starting to think like that
8:19:00 AM
in my head. Right Game is the AR... etc.. etc
8:19:23 AM
__Bryan.Watts__
haha
8:19:47 AM
so, we have the user decision to start a game
8:20:27 AM
requiring specific opponents and possibly other stuff
8:20:43 AM
__mat-mcloughlin.net__
would you have that rather than start game
8:20:58 AM
then have people join the game
8:21:04 AM
__Bryan.Watts__
good question
8:21:17 AM
so now we have a different decision forming
8:21:49 AM
host game
8:21:51 AM
__mat-mcloughlin.net__
yeah, that sounds better
8:22:14 AM
__Bryan.Watts__
start will happen eventually
8:22:24 AM
but it's not first
8:22:27 AM
I'm thinking of this as, if I were to draw left-to-right the entire timeline of the history of one of these interactions between users
8:22:51 AM
what is that first point going to be?
8:23:03 AM
so, we want to host a game
8:23:28 AM
what kind of data do we have to provide to do so?
8:23:37 AM
game settings
8:23:59 AM
__mat-mcloughlin.net__
That depends. Rules are defined unless you play alternate rules so there is nothing to specifiy other than to say your going to play
8:24:52 AM
you wouldn't say how many people are playing as that would come from people joining
8:25:24 AM
__Bryan.Watts__
perfect
8:25:29 AM
__mat-mcloughlin.net__
but there is a max number of people
8:25:38 AM
__Bryan.Watts__
public/private?
8:25:38 AM
implying friends
8:25:41 AM
let's keep it public
8:25:44 AM
ok max number of people
8:26:03 AM
let's say we name the room
8:26:16 AM
Risque
8:26:21 AM
​​
8:26:26 AM
"I make the decision to host the game 'Risque'"
8:26:53 AM
next decision
8:27:01 AM
joining
8:27:08 AM
__mat-mcloughlin.net__
inviting?
8:27:12 AM
__Bryan.Watts__
haha was just typing it
8:27:23 AM
__mat-mcloughlin.net__
lol
8:27:29 AM
__Bryan.Watts__
what data would I provide when inviting?
8:27:39 AM
__mat-mcloughlin.net__
well I don't want to start thinking of this as a network game, so i imagine just name
8:28:10 AM
__Bryan.Watts__
agreed
8:28:28 AM
so you want to invite Bob
8:28:32 AM
"I decide to invite Bob to 'Risque'"
8:29:02 AM
can people discover?
8:29:19 AM
i.e. Sally decides to join the game independently?
8:29:34 AM
__mat-mcloughlin.net__
then bob has to either accept or decline
8:29:47 AM
__Bryan.Watts__
ok good, I was going breadth-first
8:30:06 AM
__mat-mcloughlin.net__
well if sally asks to join
8:30:09 AM
you then need to say yes or no
8:30:15 AM
__Bryan.Watts__
it's a totally different decision path, you were spot on there
8:30:32 AM
back to Bob
8:30:39 AM
decisions over data ​​
8:31:02 AM
Bob, through mechanisms undefined, observes the invite
8:31:32 AM
his decision is to accept or decline, as you said
8:31:49 AM
"I decide to join 'Risque' thanks to Mat"
8:32:17 AM
__mat-mcloughlin.net__
(damn we haven't even started the game yet ​​)
8:32:27 AM
__Bryan.Watts__
it's collaboration man
8:32:38 AM
more complex than we give it credit for
8:32:47 AM
these are the decisions available to everyone involved while setting up the game
8:33:23 AM
the next is to start the game
8:33:54 AM
what kind of issues could we encounter that would invalidate our decision to start?
8:34:25 AM
__mat-mcloughlin.net__
I'm just writing this down
8:34:28 AM
__Bryan.Watts__
​​
8:34:36 AM
nobody else wants to play!
8:34:46 AM
__mat-mcloughlin.net__
got to be at least 2 playes
8:37:03 AM
FYI rules change dependent upon the number of players
8:37:20 AM
__Bryan.Watts__
is that all they depend on?
8:37:29 AM
i.e. are we missing any switches we might need to flip later?
8:37:43 AM
__mat-mcloughlin.net__
so if you stick to standard rules that is the only flag I can think of
8:38:44 AM
__Bryan.Watts__
great
8:39:11 AM
so we can say the decision to start a game is available when the number of plays is at least 2
8:39:27 AM
*players
8:39:33 AM
one last administrative thing
8:39:51 AM
can players leave a game?
8:40:00 AM
and, can they be booted?
8:40:32 AM
__mat-mcloughlin.net__
they can forfiet
8:40:33 AM
__Bryan.Watts__
before it starts
8:40:38 AM
we haven't started yet
8:40:40 AM
sorry, regressed a tiny bit
8:40:46 AM
we didn't cover the pre-game decision space
8:41:08 AM
the other decisions, briefly, are "I decide to leave a game before it starts"
8:41:31 AM
"I decide to block another player from this game"
8:41:55 AM
and the last detail
8:42:09 AM
the decision to join a game is available only when the game is not full
8:42:22 AM
*full = players == max players
8:42:33 AM
with me?
8:42:46 AM
__mat-mcloughlin.net__
yep
8:42:49 AM
__Bryan.Watts__
now, here's an exercise I probably find more fun than I should
8:43:07 AM
when inviting players, we didn't quite nail down everything
8:43:21 AM
the provided data for that decision is a username
8:43:52 AM
that implies the available data for the decision is the set of usernames
8:44:05 AM
except those already in the game
8:44:18 AM
the decision to invite a user is also available only when the game is not full
8:45:10 AM
therefore, we can summarize
8:45:19 AM
__mat-mcloughlin.net__
k
8:45:40 AM
__Bryan.Watts__
The decision to invite a player to a game requires a username, from the set of usernames not already in the game. This decision is available when the game is not full.
8:46:16 AM
what you read there is
8:46:24 AM
command structure, read model, when "enabled"
8:46:54 AM
__mat-mcloughlin.net__
k
8:47:01 AM
__Bryan.Watts__
looking back on other decisions
8:47:24 AM
we can say that the decision to start the game requires no data and is available when the game has 2 or more players
8:47:59 AM
the point I'm making, I realize now in a long-winded manner
8:48:13 AM
is that each decision implies the commands, events, and UI
8:48:43 AM
it tells us what we need to see to make the decision
8:48:52 AM
and thus what we need to provide to allow the UI to render so it can provide the decision
8:49:06 AM
__mat-mcloughlin.net__
yeah
8:49:24 AM
I get that
8:49:33 AM
__Bryan.Watts__
it also tells us what projections to write ​​
8:49:39 AM
__mat-mcloughlin.net__
but would you worry about projections at this point?
8:49:58 AM
__Bryan.Watts__
nope
8:50:03 AM
and good call
8:50:08 AM
really I'm just laying out how I think about commands and what I'm seeing when I say each decision
8:50:44 AM
teach a man to fish and all that
8:50:50 AM
__mat-mcloughlin.net__
​​
8:50:56 AM
__Bryan.Watts__
let's think about that timeline again
8:51:35 AM
we now know the points on it are: "host game", "invite Bob", "invite Sally", "accept (Bob)", "accept (Sally)"
8:52:19 AM
but that's not right, is it?
8:52:36 AM
really it's "game hosted", "Bob invited", "Sally invited", etc.
8:52:48 AM
__mat-mcloughlin.net__
the events yes?
8:53:03 AM
__Bryan.Watts__
right
8:53:10 AM
we started talking in commands
8:53:15 AM
but a timeline is events
8:53:18 AM
the transition is aggregates
8:53:26 AM
so that's the next step
8:53:30 AM
transaction boundaries
8:53:33 AM
hosting a game introduces a new boundary
8:53:50 AM
the gut reaction is to say "well right, a game is a boundary because it's the natural containing thing of all of this"
8:54:32 AM
__mat-mcloughlin.net__
thats what I was thinking
8:54:45 AM
__Bryan.Watts__
me too
8:54:52 AM
I started thinking about what I was thinking
8:54:57 AM
so this is off the cuff
8:55:03 AM
but hear me out
8:55:05 AM
__mat-mcloughlin.net__
go for it
8:55:12 AM
__Bryan.Watts__
containment is a spatial concept
8:55:18 AM
transaction boundaries are temporal concepts
8:55:24 AM
that's why we mistake entities for aggregates
8:55:39 AM
__mat-mcloughlin.net__
ok
8:55:56 AM
__Bryan.Watts__
so I'm not going to immediately jump to Game aggregate
8:56:06 AM
__mat-mcloughlin.net__
so where's your thinking going?
8:56:10 AM
__Bryan.Watts__
instead, let's think about those decisions
8:56:12 AM
and how they affect each others' data
8:56:23 AM
host game: creates a new boundary
8:57:08 AM
invite user: obviously affected by host game because it is part of the provided data
8:57:39 AM
we have to provide a game with that decision, so invite user is dependent on host game
8:58:10 AM
they belong in the same boundary
8:58:15 AM
next, invite user
8:58:34 AM
we provide the username
8:59:10 AM
so it doesn't require any other data besides the game
8:59:30 AM
so it also belongs in that boundary
8:59:38 AM
how about accept invite
9:00:00 AM
it doesn't require any data, but it does affect the available data for invite user
9:00:18 AM
so it belongs in the same boundary
9:00:30 AM
start game has an issue if there are not at least 2 players, so all the invites affect its data, and it belongs in the same boundary
9:01:19 AM
__mat-mcloughlin.net__
...
9:01:27 AM
__Bryan.Watts__
we have absolutely determined that the set of commands all affect the same boundary
9:01:38 AM
__mat-mcloughlin.net__
carry on... but this is still leading me to think that game is the boundary
9:01:50 AM
__Bryan.Watts__
:itsatrap:
9:02:05 AM
damn
9:02:06 AM
:ackbar:
9:02:11 AM
ah well
9:02:15 AM
__mat-mcloughlin.net__
lol
9:02:16 AM
however
9:02:21 AM
is there a distinction between pre game and game?
9:02:46 AM
__Bryan.Watts__
nailed it
9:02:52 AM
I was working up to making the implicit explicit
9:02:58 AM
by showing that every decision after start game is not in the same boundary
9:03:07 AM
__mat-mcloughlin.net__
ha, this is good ​​
9:03:55 AM
__Bryan.Watts__
very
9:04:17 AM
so what do you think of Lobby? or Room?
9:04:26 AM
__mat-mcloughlin.net__
...
9:04:41 AM
they feel linked to network gaming
9:05:01 AM
I've been thinking of this as more of people sat around a table or something. But that might not be a bad way to go
9:05:23 AM
__Bryan.Watts__
well, I play Titanfall constantly so I have seen that distinction become less pronounced ​​
9:05:32 AM
__mat-mcloughlin.net__
lobby might not be a bad way to go
9:05:54 AM
__Bryan.Watts__
yeah it's just people getting together to coordinate
9:06:05 AM
doesn't have to imply all the other social crap that usually comes with
9:06:14 AM
I'm thinking Hearthstone or Scrolls or something, where it's a single-player experience over the network
9:06:44 AM
__mat-mcloughlin.net__
Lobby suggests somewhere you wait. Room might be better
9:07:06 AM
__Bryan.Watts__
er, feels like single-player
9:07:06 AM
yeah
9:07:14 AM
pre-game works too
9:07:17 AM
I just didn't want to make the classic cart/order mistake ​​
9:07:26 AM
__mat-mcloughlin.net__
​​
9:07:33 AM
yeah
9:07:35 AM
__Bryan.Watts__
one more thing to point out
9:07:59 AM
we haven't talked for very long, and we've already nailed down basically everything we would need to implement this in any tech stack
9:08:19 AM
(the lobby part)
9:08:40 AM
__mat-mcloughlin.net__
yep
9:09:09 AM
__Bryan.Watts__
I just realized I framed you as a client
9:09:52 AM
ha
9:09:52 AM
__mat-mcloughlin.net__
lol
9:10:02 AM
You've done this too much that its become engrained obviously
9:10:29 AM
​​
9:10:31 AM
__Bryan.Watts__
haha
9:11:05 AM
I did my time in consulting...I'm doing product now, but I bet I could go back and kill it
9:11:19 AM
not that I would ​​
9:11:24 AM
this is going to sound insane, and I know it
9:11:33 AM
but the trajectory of my personal project solves consulting on an abstract level
9:12:19 AM
it wasn't the goal
9:12:31 AM
it's a knowledge work engine
9:12:38 AM
it just so happens that a lot of consulting is just collecting and chewing data
9:13:04 AM
__mat-mcloughlin.net__
yup
9:14:17 AM
this has been good. Think I've got something to start on
9:14:47 AM
__Bryan.Watts__
definitely
9:15:23 AM
I think it's time for me to finally go to bed
9:15:32 AM
been procrastinating on that ​​
9:15:38 AM
__mat-mcloughlin.net__
lol
9:16:11 AM
before you finally go, you had one more point?
9:16:29 AM
__Bryan.Watts__
did I? ha
9:16:44 AM
oh
9:16:53 AM
it was the efficient nature of this design orientation
9:17:04 AM
you would be amazed how much talk in meetings could be just, freakin eliminated
9:17:31 AM
people talking about this data and that data and what about when someone wants to do this with that data
9:17:53 AM
you get on those crazy rabbit holes like the one we almost went on, about game discovery
9:18:23 AM
because we happened to be talking about data that would also be relevant in that decision
9:18:37 AM
looking from the decisions' point of view, these things are fairly unambiguous
9:18:52 AM
so yeah
9:18:53 AM
that
9:18:54 AM
​​
9:18:56 AM
__mat-mcloughlin.net__
​​
9:20:13 AM
thanks for this man
9:20:19 AM
appreciate the time
9:20:24 AM
*I
9:20:27 AM
__Bryan.Watts__
yeah no problem
9:20:33 AM
always looking to sharpen the sword
9:20:39 AM
I find that blogging is very difficult because of the static audience
9:20:49 AM
I like interaction
9:20:51 AM
__mat-mcloughlin.net__
Yeah
9:20:59 AM
I agree
9:21:02 AM
Although I like to take notes after a conversation like this
9:21:13 AM
So I should probably blog them ​​
9:21:19 AM
FYI https://github.com/mat-mcloughlin/DDD-Risk
9:21:23 AM
__Bryan.Watts__
awesome
9:21:51 AM
watched
9:21:52 AM
__mat-mcloughlin.net__
Right. I'm gonna write my first test ​​
9:22:13 AM
__Bryan.Watts__
nice
9:22:26 AM
__mat-mcloughlin.net__
And I think you're right
9:22:35 AM
I'm going to try and let the arch flow out of this
9:22:46 AM
__Bryan.Watts__
(sent to @z3roshot, my cousin)
9:22:54 AM
definitely
9:23:01 AM
I think it will come organically
9:23:07 AM
this can all be done with simple classes
9:23:14 AM
it's really how spread-out and how persistent you want it to be that makes the difference
9:23:26 AM
otherwise command = method and query = property
9:23:35 AM
that's the easiest domain in the world
9:23:39 AM
__mat-mcloughlin.net__
well I'll just start by raising the events and see where it goes from there
9:24:24 AM
__Bryan.Watts__
are you thinking event classes?
9:24:44 AM
or an event mechanism?
9:24:51 AM
__mat-mcloughlin.net__
I'm not sure I understand
9:25:17 AM
__Bryan.Watts__
hehe sorry
9:25:26 AM
there are 3 flavors of events
9:25:33 AM
.NET raw
9:25:37 AM
IObservable<>
9:25:41 AM
__mat-mcloughlin.net__
ah
9:25:44 AM
ok
9:25:46 AM
__Bryan.Watts__
each event gets its own class
9:25:46 AM
so what I'm wondering is, when you publish
9:25:53 AM
are you publishing new GameStarted
9:26:01 AM
or doing something like "_gameStarted.OnNext(...)"
9:26:12 AM
I guess I am wondering what you meant by "raising the events" ​​
9:26:22 AM
__mat-mcloughlin.net__
GameStarted
9:26:31 AM
__Bryan.Watts__
sweet
9:26:39 AM
corresponding commands
9:26:44 AM
__mat-mcloughlin.net__
yup
9:26:49 AM
__Bryan.Watts__
you don't even need aggregates, you can do everything with just those ​​
9:26:56 AM
get those rules right later haha
9:27:01 AM
__mat-mcloughlin.net__
Right
9:27:22 AM
I'll make a start and you can rip it to shreds at your pleasure ​​
9:27:38 AM
__Bryan.Watts__
hahahaha
9:27:49 AM
__mat-mcloughlin.net__
file => new project
9:27:51 AM
__Bryan.Watts__
you have no idea what you invited yourself into
9:27:55 AM
__mat-mcloughlin.net__
lol
9:28:02 AM