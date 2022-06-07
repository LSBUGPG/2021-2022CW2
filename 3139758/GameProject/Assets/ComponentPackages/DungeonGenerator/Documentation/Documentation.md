# 2D Top Down Dungeon Generator
Add these components to your game to make randomised top down dungeons.

## Contents
This component is made up of the following states:

- "AddRoom"
- "Destroyer"
- "RoomSpawner"
- "RoomTemplates"

### AddRoom
This component is attached to each room prefab so that when they are spawned, they are added to the list of rooms on the RoomTemplates script.

### Destroyer
This component is attached to an empty game object at the centre of the starting room and detects if a closed room has been spawned on top of it, and destroys it if there is one, to avoid overlapping rooms.

### RoomSpawner
This component is attached to spawn points located at a distance from each doorway in each room prefab, each with an integer corresponding to each direction. It spawns rooms taken from the different RoomTemplates arrays depending on which direction it is, so all doorways connect properly. It detects if it collides another spawn and destroys it to prevent rooms being spawned on top of each other endlessly. It also accounts for the event of spawns being instantiated and colliding with each other at the same time, by checking if the other has spawned anything, and spawning a closed off room if not, to prevent doors being empty and leading to outside the dungeon. Spawners are then destroyed after a certain amount of time which can be adjusted.

### RoomTemplates
This component is attached to an empty game object and is used to hold arrays of room prefabs to be accessed by the spawners. There are 4 arrays for each direction, so rooms with doors of a certain direction will be grouped together to allow them all to connect when spawned. It also uses a list, in which each spawned room is added via the AddRoom script, to find out which room was spawned last, so that a boss or exit or any other prefab can then be spawned there, to create an end to the dungeon.
