# Programming Journal

## 10/11/2021
Tried using a raycast to detect ground layers below the player which proved to be very problematic, first being at 0 distance the raycast failed to detect collisions, second being the object had to be exactly center below the player object to be detected. Instead I used a CheckSphere() method to detect ground layers to prevent these issues.
