# CW2-Journal

## Programming Journal

### 04/02/2022

Getting started on the packages. Going to build them all in mind for the game project, which is going to be a top down shooter.
Starting with player movement and shooting mechanics. I made the camera a child of the player to follow them, but had an issue with the camera spinning round
(direction player is facing is dependant on the position of the mouse cursor in relation to the camera and screen space), removed the camera from being a child
to the player and added a script to allow it to follow the player independently.


### 05/02/2022

Working on enemy AI today. Tried adapting a script I used in a previous project but I used it in a 3D game rather than 2D so there were some issues in translating
it. Instead opted to follow another tutorial, producing an AI which follows and shoots at the player.


### 09/02/2022

Implemented health and damage systems. Have a health bar set up for the player, although adapting the same script to the enemy health system throws up an error.
Wanted a health bar that floated above the enemy and went down with damage, but threw up errors. Disabling it for now.

### 12/02/2022

Implemented two different types of enemies, one melee attacker, one ranged attacker, both follow the player. Attempting to implement a patrol through adapting a
previously used script, but again this one did not prove useful, the enemy would not leave the patrol state despite the player being within sight range. Will 
investigate further when I can.


### 15/02/2022

I now have three types of enemies. The third and final type has a homing projectile to shoot at the player. They can all give and receive damage and die. Next
I will focus on implementing dialogue and inventory systems.

### 22/02/2022

Added a minimap that follows the player, providing a higher aerial view of the surrounding space. Scrapped the dialogue and inventory systems as they proved
difficult and cumbersome. Going to focus on simpler systems to implement.

### 28/02/2022

Implemented a score system where when the player kills an enemy, they gain a set number of points. Additionally added some pick up items including a coin, which
further increases the score, a health boost which heals the player, and a speed boost which does what it says on the tin and speeds up the movement of the player.

### 08/03/2022

Added menus. Now have a main menu with which the player can either enter the game or quit, a pause menu which lets the player stop the action and then return to the
game, quit the game or return to the main menu. Also added a game over screen which allows the player to either quit the game or return to the main menu.
There are some issues however, as the “return” button on the pause menu doesn’t work, instead having to rely on pressing the escape button to go back to the game. 
Additionally, the game over screen doesn’t correctly freeze time in the game, with enemies still attacking the player in the background, as well as the player being
 able to still move and shoot. Will look up solutions for this.

### 10/03/2022

Added some code to the enemy movement scripts to allow them to rotate to look at the player's transform wherever they move to, which also allows for the fire point to
stay facing the player and projectiles to fire in the correct direction.

### 14/03/2022

Adjusted the triggers on the enemy projectiles to correctly interact with the player's circle collider trigger. Also adjusted the melee enemy's trigger distance to be
further around the enemy sprite so that it doesn't try to move directly into the player's space, causing a bug. Also changed the OnTriggerEnter to OnTriggerStay, as the
player could simply stay within the trigger space of the enemy and not receive damage until leaving the trigger space and re-entering it.

### 18/03/2022

Fixed the menu issue by introducing a bool to determine whether or not the game has entered a game over/pause game state. Also added a bit of pop up text to let the
player know they have won the game once they have reached a score of 40, prompting them to exit the game to either restart or quit.

### 25/03/2022

Begun the process of breaking down the main project into the four separate packages. There will be a movement package, enemies, pickups and score/health packages.

### 01/04/2022

Packages are sorted. Game project is also finished, so will now focus exclusively on the AGP and organic modelling modules. Researching movement for a parkour type game.

### 08/04/2022

I had previously written a movement script for the AGP, although I have concerns with the way the camera is used as I followed a tutorial to complete the task. The camera
is a child of the player, so during movement it appears a bit buggy. It is serviceable for now, but will return to this in the future to improve it.

### 15/04/2022

Added the ability to wall run/jump to the player. Again the camera issues appear, but again I will return to this as it is working well enough to show my intentions for the project.

### 22/04/2022

Added moving platforms to AGP. Imported the scripts from a previous project, but they seem to not work in this project for some reason. The previous script would work in some scenes
but not in others which was frustrating so I simply rewrote it with some tweaks and it seemed to work.

### 29/04/2022

Tried to add different movement systems to the AGP to see if they fare any better with the camera situation, but keeping the original system so as not to lose any progress. I have
made some progress in regards to a third person movement script, which can also wall run and grapple, but it could do with some fine tuning.

### 04/05/2022

Finished up with the programming module so I am in the process of putting it all together within a ZIP file. The four packages, as well as the necessary files from the game project
are in there and ready to go.
