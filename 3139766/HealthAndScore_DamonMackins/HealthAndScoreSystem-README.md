# Player movement and shooting

 Package with health and score systems.

## Example Scene

This scene contains a player prefab object with movement and shooting mechanic, enemy AI, minimap, health bar and score
system.

### Player

The player is able to move the player object around with the WASD and arrow keys. To rotate the player object around,
the player needs to move their mouse cursor, and to shoot, use the left mouse button to fire a shot. This is handled
through the **PlayerMovement**, **Shooting** and **Bullet** functions.

### Enemies

There are three enemy types. They are all capable of dealing damage to the player, which is reflected in the health bar.
One damages on touch, one fires a projectile that flies straight, and one fires a homing projectile that follows the
player. These use the **EnemyHealth**, **EnemyFollow**, **EnemyShoot** and **EnemyHomingShoot** functions.
Defeating these enemies grants points.

### Health bar

The health bar will show the damage the enemies are dealing to the player through the **PlayerStats** and **HealthBar**
scripts.

### Score system

The score system at the top of the screen tracks how many points are earned through destroying enemies. This is managed
by the **ScoreManager** script.