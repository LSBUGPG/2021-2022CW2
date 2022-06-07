===First Person Shooter Unity Package===


---Setup---
1. Create a Layer called "Ground" and assign it to any surface the player will stand on
   - Go to the FPS Player Prefab and change the Layer Mask setting in the inspector to include Ground
   - If other Layers will be stood on they should also be selected

2. Assign the Bullet and BulletPredict prefabs to the FPS Player Prefab
   - If another Bullet is supposed to be used instead then assign that

---Activate---
   - Use WASD to move
   - Press left click to shoot (The player has a cooldown which can be adjusted in the inspector)