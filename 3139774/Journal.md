# Programming-Journal-2
Semester 2 programming 



# Week 2 package 1 Movement in 3D

## Introduction 

The goal for this semester is to make 4 packages that work on their own and have some relevance to the game that I'm working on and looking to make for my mechanical demo.For my mechanical demo, I'm looking to make a 3D platformer with combat mechanics as a basis. First things first I'd have to work on the meat of the game which would be to make the movement of the game.

## Making the movement

First things first I had to set the scene. I made a 3D scene within Unity and created an empty terrain and moved the camera into a position where it could see the player, but now I needed to have a character that I could work on, which I didn't. So to have something to test, I decided on making a capsule 3D object, and made a material to help make it stand out. Now I needed to add a rigidbody to it so that there's gravity to our player so that whenever he's in the sky. Next I needed to make a new script, that would essentially act as a character controller. After making the character controller in C# I increased the movement speed to see if the character would move, and it did. However, there was now one problem. The character would just roll around the scene instead of maintaining a single position as it moved. So in order to fix this I'd have to go into the rigidbody settings and essentially freeze the rotation of the character on every axis. Now it works, I have basic movement. 



Here's the code: 



using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed= 6f;
    public float turnsmoothtime = 0.1f;
    private float turnsmoothvelocity;
    public float jumphspeed = 1f;
    private float yspeed;
    private Vector3 movementDirection;
    private float velocity;
    private float rotationSpeed;
    
    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;



        yspeed += Physics.gravity.y * Time.deltaTime;


        yspeed += Physics.gravity.y * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            yspeed = jumphspeed;
        }
       

        if (direction.magnitude>=0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothvelocity,
                turnsmoothtime);
            var rotation = transform.rotation;
            rotation=Quaternion.Euler(0f,targetAngle,0f);
            rotation=Quaternion.Euler(0f,targetAngle,0f);
            transform.rotation = rotation;
            controller.Move(direction * speed * Time.deltaTime);
        }

        if (movementDirection!=Vector3.zero)
        {
            Quaternion toRotation=Quaternion.LookRotation(movementDirection,Vector3.up);

            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
      
    }

  }





Now it was time to work on jumps, I revisited the script to work on jumps in the scene so that allows our player to jump up and down. So now we have a fully working character with good movement.  Here's the code for jumping:

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    public bool Grounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& Grounded)
        {
            rb.AddForce(new Vector3(0,5,0),ForceMode.Impulse);
            Grounded = false;
        }
        
    }


}


## Making the camera move with the character 

There's many ways to do this, but the easiest way of doing this is using the function known as cinemachine. I could use the Cinemachine function to help the camera essentially focus or "look at" the player as they move. I had to adjust the distance of the camera to make the gameplay feel much more smooth, and actually having an idea of the player's surroundings, makigng it easier to notice surroundings and whatnot. 



# However, There was a problem

When running the code I had problems with my character's movement or the camera being very jittery, the reason for this was because I had issues using a character controller, this led to a plethora if issues that involved mainly colliders, and problems where the character would just float around, I tried to rerun various solutions and work on what may have gone wrong by repeating the same process again. However, after doing it the first time, I realised it'd be more smart to rework the whole movement system from scratch but instead of using a character controller I decided to make my own one and use physics more. 

## But first things first, Rework the camera

Reworking the camera this time around would be the harder part, considering that I had to make the feel of the camera just right. I instead opted for a freelook camera from the cinemachine options. Now, I needed to make sure that I had the right camera used, first things first, I'd mess around with the top, middle and bottom rigs of the camera to get the scene perfectly into view. But one problem remained, I had to fix the movement being inverted. After assigning my main camera, and then choosing to invert the camera on the Y axis, I was able to get my camera working as intended, granted I needed to play around with some more settings like the rigs, and where it is the player can look. 

## Movement and jumps

Next  came the movement itself, there were various hoops that needed to be jumped, one was that when I got my movement to work, my inputs were all wrong. the camera would follow the player fine, but the character would control funny, I'd press W and my character would move in the opposite direction, so I ended up doing some more tweaking to the code and freezing the roation along the Y axis to stop the player object from floating when it moves. 

Next came the harder part, the jump mechanic, again seeing as we're not using a character controller, none of the previous scripts I wrote would work, at one point I had the controller work but the character wouldn't jump, and the main reason for this was because things in the inspector weren't layered properly or tagged correctly, after fixing this issue I was able to get the code working and then tune the jump height to make sure that it feels natural, I then went again and tweaked the camera again so that the jump didn't affect how the player could see.

Here's the code:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    float ForwardInput, HorizontalInput;
    [SerializeField] float Spd;
    Vector3 MoveVector;
    [Space]
    [SerializeField] Transform Maincam;
    [Header("Jump")]
    [SerializeField] LayerMask GroundLayer;
    [SerializeField] Transform GroundCheck;
    [SerializeField] float CheckRadius = 0.2f;
    [SerializeField] int JumpCount;
    [SerializeField] float JumpHeight;
    bool IsGrounded;
    int JumpsRemaining;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        RotatePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    //CONTROLS FOR THE PLAYER
    void PlayerInput()
    {
        ForwardInput = Input.GetAxisRaw("Vertical");
        HorizontalInput = Input.GetAxisRaw("Horizontal");

        MoveVector = (transform.right * HorizontalInput) + (transform.forward * ForwardInput);
    }

    void Jump()
    {
        float VelocityY;
        IsGrounded = Physics.CheckSphere(GroundCheck.position, CheckRadius, GroundLayer);

        if (IsGrounded)
            JumpsRemaining = JumpCount;

        if (JumpsRemaining > 0)
        {
            JumpsRemaining--;

            VelocityY = Mathf.Sqrt(-2 * Physics.gravity.y * JumpHeight);
            rb.velocity = new Vector3(rb.velocity.x, VelocityY, rb.velocity.z);
        }

     
    }


    void RotatePlayer()
    {
        transform.eulerAngles = new Vector3(0, Maincam.transform.eulerAngles.y);

        
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector3(MoveVector.x * Spd, rb.velocity.y, MoveVector.z * Spd);
    }
}


 
  Pretty simple code overall, I'm basically telling the code to tell the player to move along the vertical and horizontal axis' and to also allow the player to jump when the spacebar is pressed, only when the player is in a state where they're not jumping but are able to jump if they're touching the ground, to check this I created an empty gameobject called "Groundcheck" in order to check if the feet of the player is touching the ground, then tell the script that we can jump when we're touching the ground.


# Week 3 package 2 Setting a scene 

## Moving platforms 

First things first, I wanted to make the scene. Considering the goal of the game is to make a 3D platformer with melee abilities I want to work on implementing different types of structures, the first of these being moving platforms. to make sure this works I set up 2 platforms in the air, and thought about how I'd go about doing this. First things first I created an animator and an animation track for the object and animated movement for the platform to move. Once done I made the animation loop making it so that I had something there, and we'd have movement. 


But then there was a problem, while I do have a moving platform, my character would just slide off the platform whilst the animation played instead of staying on the platform. I wasn't too sure as to why this was. But after doing some research, I looked at doing adding more than just the animation. On the platform I added a second box collider and adjusted the height and position. 

Now the plan is to make a script that uses the trigger I've placed on the platorm. 
The script would trigger the platform to become a parent object of our player object meaning that it should stick the script looks something like this: 


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject==player)
        {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject==player)
        {
            player.transform.parent = null;
        } 
    }
}


Now it should work, at least that's what I initially thought, but even with the script on I had a problem where my character would still not stick to the platform, so I had to look for a fix seeing as everything was the same. But after looking at the script it turns out that there was nothing wrong with the script itself. The solution was in the animator component, and changing it to animating physics. 




## Collectibles Package 3  
  Every 3D platformer tend to have collectibles, for this test I decided to have collectibles I previously made and would use them in this example to try and get something working. I added them around the scene and eventually included a collection script that allowed me to destroy the object when I pick it up. I had a score but now I needed something that would show that. So I created a UI canvas and added some text to show off the Text UI on my unity scene, to display the score, and soon have something to show off the overall scoring of the amount of gems collected by the player.

First things first, I needed to set up the script that houses the scoring system in the first place. But in order to do so I'd need to create a new canvas and UI component for text the score to be updated when the collectible has been collected by the player. The script looks something like this: 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem1 : MonoBehaviour
{
    public GameObject scoreText;
    public int theScore;

    void OnTriggerEnter(Collider other)
    {
        theScore += 1;
        scoreText.GetComponent<Text>().text = "HexoGems" + theScore;
        Destroy(gameObject);
    }
}

One thing that needs to be ticked off is the "Is Trigger" option, mainly so that we can actually collect the object. This is so because without the trigger on the script can't function meaning that the box collider makes the item a solid object that collides with the player when we touch it. 

After testing, it looks like I made an error, in the script above I added the line 

 scoreText.GetComponent<Text>().text = "HexoGems" + theScore; 
  
 However, it turns out when I put "HexoGems" it will show as "Hexogems" and not "SCORE: 0" This is because I made the naming convention "HexoGems" and seeing as I'm telling the script to call on that function, it'll essentially deliver that result on screen, which isn't what I want so instead of "HexoGems" I've changed it to "SCORE:" to make sure that it now seems more appropriate in context. 
  
  
  With the changes made the script now looks something like this: 
  
  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem1 : MonoBehaviour
{
    public GameObject scoreText;
    public int theScore;

    void OnTriggerEnter(Collider other)
    {
        theScore += 1;
        scoreText.GetComponent<Text>().text = "SCORE:" + theScore;
        Destroy(gameObject);
    }
}

 After doing some more trouble shooting, I realised that I'd have to make two seperate scripts, one that essentially houses the scoring system and another that will allow the player to collect any collectibles to increase their score. So that meant I had one for collection and another for scoring. 
    
    
    After making the scoring script, I attached it to an empty game object along with UI elements to get it to basically change the score text each time a gem was collected by the player. 
  
    Here's the script for the scoring system:
    
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem1 : MonoBehaviour
{
    public GameObject scoreText;
    public static int theScore;

    void Update()
    {
        
        scoreText.GetComponent<Text>().text = "SCORE: " + theScore;
        
    }
}
    
    
Next I added a new script to the collectibles that allowed them to be colleced, using the OnTriggerEnter command, and using colliders so that this works. 
    Here's the script:
    
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
      ScoringSystem1.theScore += 1;
      Destroy(gameObject);
    }
}

    
    After some more tinkering, it works. 

  
  
  # Week 5 package 4, Working on Combat in a 3D platformer 
   
   A key element in any 3D platformer is to have enemies. Enemies will always be something that need to exist in games in order for the player to have something to interact with, whether it be jumping on them, or punching them there's so many ways for this method to occur. In my game, I've decided to go the beat 'em up route. However, the way I've gone about it is fairly different as opposed to how games would normally handle this matter. Normally games would handle it using "Hitboxes" I decided to handle it with something I call a "hit point". A small technique I learned that makes attacks much more realistic and accurate in the nature of how they work. For instance, a punch for example will be the most impactful at the fist, seeing as where that's where all the initial pressure ends up. To emulate this, I essentially added a massive sphere to be in place at the end of the punch, with a damage script that deals damage to the enemies. 

## Enemies 
Enemies are a very core part of how this works since it's them we'll be hitting. I set up some quick enemies to stand idle, as the main focus of this part is to get the enemies low on health. So after importing a couple and copying and pasting them, I decided to work on their health scripts and add a canvas with a number that essentially displays the health of the enemy. First things first, I got some enemies that I made, and added a script to them, this script essentially gives the enemy health as well as a health counter, that I'd made using the canvas in unity. 

First things first, I needed to make the enemy controller, So I made a health script and added an "Enemy layer" this allowed me to  then add a player/combat script to the player.


# Week 5 package 4 Combat Continued, Shooting a projectile. 
    
    For this, I wanted to wotrk on shooting a projectile from our character that would kill any enemies we have. Some games have this and I feel like it's more enjoyable than being able to shoot enemies at a range. 
    
    First things first I needed to write a script that would instantiate an object (being the projectile), and also tell the object what way to fire, and what the force and speed of the projectile should be. 
    
    
    Here's the code:
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject Projectile;

    public Transform Firepoint;

    public float force;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Fireball P = Instantiate(Projectile, Firepoint.position, Quaternion.identity).GetComponent<Fireball>();
            P.direction = transform.forward;
            P.Speed =force;
        }
    }

    public float Speed { get; set; }
}

    
    After adding this, I needed to make sure that the projectile would destroy any objects, being the enemies here. After doing so, it worked. 
    
    
    # Week 6 Package 5 working on a timer system 

    Part of the goal for my mech demo is to try to get the player to complete the level the fastest way they can, and try to complete the level in the best possible time that they can, when they reach the goal. This was a small package to make it's a culmination of one script and a text component. First things first, I created a text object inside the existing canvas that I already have, I then went to work on the script, straight after here's the script: 
    
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds;
    }
}




## Package 7 Text showing on trigger 

  One important thing about games is teaching the players how to play the game, I'm using hints to do this but via a destroyable object using an ontrigger component, on a box collider. 

First things first I wanted to make something the player could interact with, so I made an exclamation mark in Maya, and exported it to unity. this would be our base.
    
    Next I added a script to the object that would house a place where I could put in whatever I wanted into a text box in the inspector. 
    
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject;

    private void Start()
    {
        uiObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag=="Player")
        {
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(uiObject);
        Destroy(gameObject);
    }
}

    
    
    
    
    

    
    
    
## Package 8 Making a dash 
      
 I wanted to enhance gameplay a little more, so to do so I included a dash to my work, with some particles. With my game I wanted to make it so that the character could have some significant speed when moving, and being able to dash midair for extra leverage. Meaning there's more the player can do to complete the level/game in the best time they possibly could get. Here's the script. 
    
   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashSpeed;
    Rigidbody rig;
    bool isDashing;

    public GameObject dashEffect;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            isDashing = true; 
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            Dashing();
        }
    }

    private void Dashing()
    {
        rig.AddForce(transform.forward * dashSpeed, ForceMode.Impulse);
        isDashing = false;

        GameObject effect = Instantiate(dashEffect, Camera.main.transform.position, dashEffect.transform.rotation);
        effect.transform.parent = Camera.main.transform;
        effect.transform.LookAt(transform)
    ;
    }
}
    
    
In the script, I wanted to make sure that the player has some form of dash, so I'm just asking the script to let the player dash when the player presses shift. 
    
  ## Adding new hazards
    
    
    Seeing as this was a game that requires the player to finish the level as fast as they can, I included some extra obstacles like moving walls, so that when you hit them, they'll cause the player to fall. Making them start again. I made it so the player could maybe use these to elevate themselves if they use their jumps right or they get hit, causing them to start again. The initial problems I had with these were that 
 

