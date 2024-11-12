# RockJourney
**Group number 3**

- Noemi Messori, student no. _202401607_, email _up202401607@edu.fe.up.pt_   
- Lorenzo Piarulli, student no. _202401433_, email _up202401433@edu.fe.up.pt_

## YouTube Video

[YouTube Video](https://youtu.be/ibwuZbDkA0E)

## Instructions on how to play the game:
The game is provided as a Windows executable. To start playing, simply double-click the executable file. 
Use the **WASD** keys on the keyboard to move the player. Press **ESC** to pause the game.
As the name of the game suggests, the player takes on the role of a rock. The rock's goal is to collect all the crystals while surviving attacks from enemies. There are two types of enemies: the first one pursues the player following him, while the second can attack from a distance shooting at him from a turret. Both enemies can only reach the player if they are in a position to see it.

## Game
Starting from tutorial 2, we introduced several upgrades across different categories: enemies, graphics and UI, sound design, and camera view.

### Enemies
There are two types of enemies:
- The first type is a turret that aims to shoot at the player but can only fire when the player is within its line of sight. Each time it shoots, it emits a distinct sound.
- The second type is a chaser that actively follows the player, but it can only pursue if it has the player in sight.
As the levels progress, the number of enemies increases, making the game more challenging but also more rewarding for the player.

### Graphics
To enhance the game’s visual appeal, we decided to replace all models by importing assets from the **Unity Asset Store**. We opted for a **low-poly style**, bringing in trees, rocks, and rock walls to match this aesthetic. Additionally, we implemented a **toon shader** to create materials that complement the game’s overall look.
To complete the game’s look, we used the **post-processing plugin** to add finishing touches, including filters, motion blur, hue adjustments, grain, and other effects. 
The UI has also been enhanced, displaying lives, level number, and the coin count. We implemented a pause menu, a start menu, as well as win and lose screens.

### SoundDesign
We introduced sounds for the most important things in the game, such as the reach of the crystal, when the player dies, when the player is hitten and when the enemy turret shoots. Furthermore, we included some soundtracks to the game, taken from Bastion, developed by SuperGiant Games.

### CameraView
To make the game more interesting, we decided to change the point of view of the game moving the camera's position to a **top-down** position. This helps to create a more dynamic and strategic game, giving the opportunity to the player to make some strategic choices during the game itself. 

### WayPoints
Another introduction to the game was the inclusion of _WayPoints_. These help the player to find in a more easily way the crystals and to avoid at the same time in the best way possible the enemies.


