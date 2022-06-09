/*
 * This package provides a player controller which gives a fixed look direction whilst allowing the player to move through 3d space.
 * To get it working in your game drag the prefab onto your scene.
 * There is also an example scene you can also use as a template provided in the package.
 * I have also provided a character model to demonstrate how the player trasitions to look in the direction that they are moving.
 * This can easily be replaced by deactivating or deleteing the object under GFX which childs the Player prefab.
 * You can then place your character model to child this GFX object and you will be able to move your own character.
 * This package also uses Cinemachine to achieve the smooth animated camera and idle camera movement.
 * There are some settings in the inspector of the Player game object within the player controller for additional customisation.
 * The first setting is speed which will control how quickly the player will move (you can also play with drag in the rigidbody
 * of this object if you want the player to move really fast without them sliding around everywhere.
 * The next setting is a switch that just activates and deactivates the movement of the player (this is a public varible so its 
 * most likely to be used through script comunication of addition scripts you make yourself to activate and deactivate. For example
 * when an NPC is talking and you don't want the player to wonder off.)
 * Look smoothing is to adjust how quickly the character looks in the direction that they are walking (too low and it will look snappy).
 * PlayerGFX can be left alone as long as you set up your player the recommended way of keeping the GFX object and getting your new 
 * model to child it.
 * The look point can also stay the same as thats where the camera will aim to look although you can move this game object to provide
 * unique results.
 * 
 * From there you will have a complete animal crossing style player controller.
 * Enjoy - Jamie
 */