# **Basic Rigidbody Controller Pack**
***

The aim of this package is to give the user a stable and modular character controller that utilises Unity's forces system and also provide dynamic movement to held objects.


## **User Manual**
***

#### **Follow Target**
Sets the position of the main camera to another object attached to the player to prodive image stabilization and eliminate jitter 


#### **Player Look Script**
This script provides a base level of camera control to operate the main component of this package and
can be replaced by the users own implemenation of camera control solutions

#### **Player Movement**
Provides the basis of the force controller including:
* Basic movement
* Slope handling
* Jumping (with adjustable height and jump count)
* Dynamic and Static Drag values
 

#### **View Bobbing**
Adds viewbobbing to the character controller to humanize movement, attaches to the same object that contains the Player's Movement Script/Rigidbody

#### **Viewmodel Sway**
Moves a viewmodel object based on movement input, camera movement, Y-axis velocity
Viewmodel displacement and rotation speeds and max amplitudes are adjustable

## **Example**
****
To make use of this package or set up your own character from the materials provided please refer to the demo scene and base your character hierarchy as demonstrated