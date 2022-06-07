# 2D Collectibles
Add these components to your game to make coin and health collectible items. This package uses TextMeshPro.

## Contents
This component is made up of the following states:

- "Coin"
- "HeartCollect"
- "Hearts"
- "ScoreManager"

### Coin
This component is attached to a coin object and detects if the player collides with it, which will add to the score in the ScoreManager script. The value one coin has can be modified.

### HeartCollect
This component is attached to a heart object and, like the Coin script, detects if the player collides with it, which will add to the player's health in the example health script, but only does so if the health is below the maximum health. How much health is added can easily be changed in the script.

### Hearts
This component is attached to the player and is used to display the player's current health in the UI by accessing an example health script. It uses 2 different images, a full heart and an empty heart, and updates them as the player's health goes up and down, so when they lose a heart, the first will be empty, if they lose another, the second will be empty, and if they gain a heart, the second will be full again, and so on. The number of hearts can be modified.

### ScoreManager
This component is attached to an empty game object and keeps track of the score and displays it in the UI. Any coins that are collected are added to the score which will then update the text.
