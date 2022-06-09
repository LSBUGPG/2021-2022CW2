# Player movement and shooting

 Package with player movement and shooting mechanics.

## Example Scene

This scene contains a player prefab object with movement and shooting mechanic.

### Player

The player is able to move the player object around with the WASD and arrow keys. To rotate the player object around,
the player needs to move their mouse cursor, and to shoot, use the left mouse button to fire a shot.

The movement is managed by the **PlayerMovement** function, while the shooting is managed by the **Shooting** function.
The bullet is managed by the **Bullet** function, which ensures that when it hits an object or has travelled for a certain
period of time, it will be destroyed and removed from the scene.

### Camera

The camera is controlled by the **CameraLook** function and will follow the player's transform but not the player's rotation,
to allow for free player rotation with the mouse cursor without the camera being affected.