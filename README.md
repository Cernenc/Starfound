# Starfound

I welcome you to Starfound!

## Story
In this side-scrolling platformer you control the character "Star", a music composing star who animates his friends with dances and music to brighten up the night sky.
One day he collides with a mysterious meteor by accident and loses almost all his power and crashes, alongside the meteor, to earth.
Eager to be with his friends and let the night shine again, Star is on the pursuit of the meteor to get his powers back.

## Gameplay
As mentioned, Starfound is a side-scrolling platformer; your character moves automatically. By input you move your character upwards. Your goal is it, to reach the end of each level and get closer to the meteor - but just like the end of each level in Super Meatboy, your goal escapes at the last second. <br />
![flying](https://user-images.githubusercontent.com/61525019/141357206-4cb90eee-afd2-47c6-84fa-7645a2eabd0b.gif)

### Overview
![Ovw](https://user-images.githubusercontent.com/61525019/141356596-c02441ca-1ca2-4704-9ebc-47b5af655d7f.PNG) <br />
In order: Star, health, enemies, collectables

### 1. Star
The protagonist of Starfound that you are controlling. After involuntarily landing on earth it is his goal to get back to the sky and be with his companions.
Star is the maestro of his kind and a good one at it. The power of music drives him further and further to be the best at what he is and can be.

- Abilites 
With music, Star powers up and (temporarily) gains abilities. By collecting musicnotes Star refills his stamina. Certain notes are added to the inventory for later use and give Star power ups.
Stars abilities are:
- Speed up
- Spin -> reflects incoming projectiles
- Power of friendship -> Find friends scattered in every level. Each friend gives one stack of friendship. Each stack activates its effect then the effect -1 up to one stack. Up to three friends can be found in one level.

No. of Stack(s) / effect <br></br>
One stack: destroys every enemy and projectile on screen. <br></br>
Two stacks: collects all notes on screen. <br></br>
Three stacks: opens a secret exit. <br></br>

### 2. Health
Your health or, to be more precise, your fuel. Star is running on fuel and loses same continually. After depleting all resources Star loses and explodes (think Megaman).
Collectables fill up your health. Enemies damage you and make you lose health, also make you start at your starting position. <br />
![health](https://user-images.githubusercontent.com/61525019/141357213-0c413ca8-855a-4437-97db-06da75ae10d5.gif) <br />
Lose health: automatically, by enemy. Gain health: collect

### 3. Enemies
The obstacles of the game. Enemies go with two states depending on the players position: A normal state and an enraged state.

#### 3.1. Normal state
Default behaviour of an enemy. They do their thing. When the player enters their trigger range though -> become enraged

#### 3.2. Enraged state
The enemy becomes angry and changes their behaviour. Exit the trigger range to (eventually) calm the enemy.

For now, there are two types of enemies: Ants and bees.

#### 3.3. Ant
Normal state: The ant moves back and forth on his platform. When it reaches the end of the platform it turns around because it doesn't want to fall off (obviously). Its behaviour resembles a green Koopa from Super Mario.
Enraged state: When it gets enraged it moves back and forth but faster. Its behaviour resembles an angry Wiggler from Super Mario
Ants damage the player by contact

#### 3.4. Bee
Normal state: The bee, more precisely the beehive, is a stationary object that doesn't move or do anything.
Enraged state: It shoots forth x bee projectiles - or how I'd like to call it, beejectiles - in the direction of the last known position of the player.
The projectiles die after a certain amount of seconds or when they hit the player. They also can be deflected with a spin
The beehive and the projectiles damage the player by contact.

### 4. Collectables
Collect Music- and Specialnotes to fill up your health. Each note grants Star one stack of "Speedcounter" and increases his base speed by x%. Speedcounter reset when getting hit.

#### 4.1. Specialnotes
Specialnotes are different from Musicnotes. Collect them and add them to your inventory. Activate an item by a press of a button <br />
Current Specialnotes:
- Speedupnote -> speeds up Star for x seconds by y amount
- Spinnote -> creates a reflector for x seconds which deflects incoming projectiles
- Powernote -> activates automatically when collected. Activates "Power of friendship"
