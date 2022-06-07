# 2D Top Down Player
Add these components to player objects in your game to make a 2D top down player controller.

## Contents
This component is made up of the following states:

- `PlayerMovement`
- `Attack`
- `Health`
- `Shoot`

**PlayerMovement**
This component detects directional inputs from the keyboard's WASD and arrow keys and moves the player accordingly using a Rigidbody 2D. It detects the last direction the player is facing to manage animation Blend Trees. It also manages the ability to move when in other states. The movement speed can be adjusted if desired.

**Attack**
This component detects input from the keyboard's space bar and triggers the attack state and animation. Doing so creates a Circle Collider 2D trigger in front of the player which is determined on the player's direction and detects if an object tagged as Enemy is within the trigger. If there are several Enemy tagged objects in the collider, they are grouped together. Any Enemy that is caught in the trigger will have damage dealt to them, managed in an example script. Time between attack initiations are managed by a timer, which can be adjusted along with collider positions, enemy tags and damage dealt.

**Health**
This component creates a set amount of health for the player. It detects the player's collisions and checks if they collided with an enemy, in which case will trigger the hurt state. This lowers the player's health number and plays the hurt animation state. When the player's health reaches 0, they trigger the death state, in which no more inputs can be carried out. The player's health is adjustable.

**Shoot**
This component detects input from the keyboard's T key and triggers the shoot state and animation. This instantiates a bullet prefab that animates and flies in the direction the player is facing via Rigidbody 2D. The example bullet has a script which allows it to be destroyed on collision and deals damage to enemies when hit.