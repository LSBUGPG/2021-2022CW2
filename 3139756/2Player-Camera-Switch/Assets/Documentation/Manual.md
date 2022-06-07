2 Player Camera Switch Guide
======================

This documentation describes how to use the `2 Player Camera Switch` component in your project.

Behaviours
----------

-   \[`CharacterSwap`\]
-   \[`Collectable`\]
-   \[`ScoreManager`\]
-   \[`WallDestroy`\]

CharacterSwap
------------

This behaviour allows the user to swap between two characters, controlling one at a time and have the camera follow that player.

### Properties

-   `Character` - current character.
-   `Possible Characters` - list with player gameobjects.
-   `Which Character` - number reference of the character.
-   `Cam` - cinemachine reference.

### Script

In order to have better control of our camera we will be using Cinemachine which is a built in Unity package.

```
using Cinemachine;
```

We reference the current characters transform, in order to switch between the characters we create a list that we put them in, so for two players 0 = player 1, 1 = player 2. And then we reference our virtual camera in order to move across the players.

```
    public Transform character;
    public List<Transform> possibleCharacters;
    public int whichCharacter;
    public CinemachineVirtualCamera cam;
``` 

In the start void if the player only has one character available then they wont be able to swap.
In the update void we use the letters `Q` and `E` to scroll through our list, which can be handy if there is more than two characters in the scene.
```    
   void Start()
    {
        if (character == null && possibleCharacters.Count >= 1)
        {
            character = possibleCharacters[0];
        }
        Swap();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (whichCharacter == 0)
            {
                whichCharacter = possibleCharacters.Count - 1;
            }
            else
            {
                whichCharacter -= 1;
            }
            Swap();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (whichCharacter == possibleCharacters.Count - 1)
            {
                whichCharacter = 0;
            }
            else
            {
                whichCharacter += 1;
            }
            Swap();
        }
    }
```    
When swap is called the current character is set based on the int of the current character, that character has its movement enabled and is shown to be enabled by the character swapping its colour, meanwhile the other characters movement is disabled and their material is set to red instead.
Finally we use the cinemachine values so that the camera will always follow the current character.
    
```    
    public void Swap()
    {
        character = possibleCharacters[whichCharacter];
        character.GetComponent<movementScript>().enabled = true;
        character.GetComponent<Renderer>().material.color = Color.green;
        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if (possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<movementScript>().enabled = false;
                possibleCharacters[i].GetComponent<Renderer>().material.color = Color.red;

            }
        }
        cam.LookAt = character;
        cam.Follow = character;
    }
}
```


Collectable
--------

This behaviour allows both players to individually interact with objects.

### Script

In order to decide who gets the point we create two tags for our two players so that we can differentiate them easily. Based on who gets the point a public void from the ScoreManager script is referenced to add the point to the player.

```
private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            scoreManager.instance.AddPlayer1Score();
            Destroy(gameObject);
        }
        if (other.tag == "Player2")
        {
            scoreManager.instance.AddPlayer2Score();
            Destroy(gameObject);
        }
    }
}
```


ScoreManager
------------

This allows the players to have two individual scores.
### Properties

-   `Player1ScoreText` - UI component to display score for Player1
-   `Player2ScoreText` - UI component to display score for Player2

### Script

To make our UI nice we are using TMPRO which is a BuiltIn Unity package , as the quality of text is vastly improved and gives a lot more options for the user.
We instantiate the scoreManager so that it is not deleted and can be referenced.
Since we are using TMPRO, we need to make sure to use the TMPRO text and not the standard Unity Text

```
using UnityEngine.UI;
using TMPro;
    public static scoreManager instance;
    public static int player1score, player2score;
    public TMP_Text player1scoreText, player2scoreText;
```    
    
We instantiate the ScoreManager into the scene which is useful incase in further scenes we forget to implement it. Two voids are created for the two players which will update the text on the UI.    
    
```    
    private void Awake()
    {
        instance = this;
    }
    public void AddPlayer1Score()
    {
        player1score++;
        player1scoreText.text = player1score.ToString();
    }
    public void AddPlayer2Score()
    {
        player2score++;
        player2scoreText.text = player2score.ToString();
    }
}
```

wallDestroy
----------

This behaviour allows the player to destroy gameobjects in the scene.

### Properties

-   `Wall` - Gameobject to destroy

### Script

We reference the game object that we want to delete, we have made it so that once the user steps into an objects triggerarea (pressure plate) the wall will be destroyed.
```
    public GameObject wall;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(wall);
    }
}
```
