# 2D Top Down Enemy AI
Add these components to enemy objects in your game to make a 2D top down enemy AI.

## Contents
This component is made up of the following states:

- "EnemyAttack"
- "EnemyController"
- "EnemyHealth"
- "ItemDrop"

### EnemyAttack
This component allows the enemy to detect collisions with the player via a tag and take damage from them by accessing the damage function and health from a script on the player. An example health script is included and can be adapted as well as the amount of damage taken.

### EnemyController
This component makes the enemy move towards the player when the player is in range, and move back to its starting position when the player is out of range, which is done by targeting the position of the player and the position of its starting point and using vectors to move towards each. The range is determined by 2 integers that can be modified to increase or decrease this range, and the enemy speed can be changed as well.  This component also manages animation states for when the enemy is idle or moving.

### EnemyHealth
This component gives the enemy an adjustable health value which decreases via a function that can be accessed from another script, like an attacking player, which is included as an example. When this health value reaches 0, the enemy will be destroyed and will drop an item using the ItemDrop component, but this can be easily removed if this isn't a required function.

### ItemDrop
This component will spawn a prefab in the enemy's place once it has been defeated. It uses arrays in order for a number of different types of items to be used, which are randomly picked when instantiated using a randomised integer. Any number of items can be added.
