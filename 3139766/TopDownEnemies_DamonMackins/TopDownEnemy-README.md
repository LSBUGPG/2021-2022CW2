# Top Down Enemies
 Package with enemy AI scripts, player movement and shooting mechanics

## Example Scene

This scene contains a player prefab object with movement and shooting mechanics, as well as three different enemy types. 

### Player

The player has a **RigidBody** component which can be moved using the WASD keys (W = Up, A = Left, S = Down, D = Right),
or the arrow keys.

The player can shoot by aiming with the mouse cursor, then using the left mouse button to call the **Shoot** function,
which in turn instantiates a **bullet**, controlled by the **Bullet** function. 
When hit by one of the player's projectiles, enemies will take damage and eventually be destroyed with enough hits.

The player object has a **RigidBody** component attached, with the gravity turned to zero, as well as a **circle collider**
which acts as a trigger for enemy projectiles.

### Enemies

The enemy objects also have **Rigidbodies** with the gravity turned to zero, as well as **box colliders**.

This scene contains three enemy types, which will perform different behaviours. 

The orange enemy is melee focused, and will inflict damage on the player upon contact. Managed by the **EnemyFollow** function. 

The red enemy will shoot projectiles in a straight line which cause damage to the player on contact. Managed by the **EnemyShoot** function.

The purple enemy shoots homing projectiles that will follow the player and cause damage on contact, or disappear if no
contact is made within a certian amount of time. Managed by the **EnemyHomingShoot** function.

The enemies will also turn to face the player depending on where they move.
