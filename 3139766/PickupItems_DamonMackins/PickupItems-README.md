# Pick up items

 Package with player movement and shooting, enemy AI, minimap, health and score system and pick up items, which include: 
healing item, speed boost and coin which gives 10 points towards score counter.

## Example Scene

This scene contains a player object, an enemy (to do damage to the player and show they can heal themselves with the
healing item), pick up items (speed boost, healing item, coin), health bar and score counter.

### Player

The player is able to move the player object around with the WASD and arrow keys. This is done through calling the 
**PlayerMovement** function.

To rotate the player object around, the player needs to move their mouse cursor, and to shoot, use the left mouse
button to fire a shot. This is done through calling the **Shooting** function.

### Enemies

Defeating an enemy grants 10 points. Picking up the coin item (orange circle) also grants 10 points.
This is worked out through the **EnemyHealth** and **CoinCollectible** functions, respectively.

If the enemy does damage to the player, the health bar is affected, and if the player moves over the healing item
(red cross), some health will be restored in the health bar. Damage to the player is managed through the **EnemyHealth**
 and **PlayerStats** functions, while the heal amount from the healing item is managed through the **HealthPowerUp**
function.

### Speed boost

The speed boost item (yellow capsule) will make the player move faster, and is managed by the **SpeedPowerUp** function.

### Minimap

The minimap shows a wider area compared to the main camera view, and is handled by the **Minimap** script.