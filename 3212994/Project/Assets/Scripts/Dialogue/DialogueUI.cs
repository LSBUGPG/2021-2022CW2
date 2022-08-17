using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    public startingDialogue[] dialogue;
    public correctChoice[] corChoice;
    public wrongChoice[] wroChoice;
    private int Index;
    private CharacterController Disabled;
    private CameraController Disabled2;
    public GameObject[] Buttons;
    public Sprite[] CharSprites;
    public Image CharImage;
    private bool StopProgress,buttonsOn,closeDial,correctBool,wrongBool;

    private void Start()
    {
        // Finds an object with the character controller script in the scene
        Disabled = Object.FindObjectOfType<CharacterController>();
        // Finds an object with the camera controller script in the scene
        Disabled2 = Object.FindObjectOfType<CameraController>();

        // runs the TextProgress function as seen below
        TextProgress();
    }


    private void Update()
    {
        // If space or mouse0 is pressed, we check if the text is still typing out
        if (Input.GetKeyDown(KeyCode.Space) && TypewriterEffect.StillTyping == false || Input.GetKeyDown(KeyCode.Mouse0)&&TypewriterEffect.StillTyping == false)
        {
            // if the StopProgress bool is off...
            if (StopProgress == false)
            {
                // We run the TextProgress function
                TextProgress();
            }
            // if closeDial is true...
            else if (closeDial == true)
            {
                // enables our character controller
                Disabled.enabled = true;
                // enables our camera controller
                Disabled2.enabled = true;
                // makes the cursor invisible
                Cursor.visible = false;
                // locks the cursor inside the game view
                Cursor.lockState = CursorLockMode.Locked;

                // checks if the object should have a different dialogue UI (this is for the Capsule NPC)
                if (EnableDialogue.enabledSecondDialogue == false)
                {
                    // if you've run through all the written dialogue, this closes the dialogue overlay
                    this.gameObject.SetActive(false);
                }
                // checks for any other option
                else
                {
                    // if you've done everything to get over the 'Senpai Paywall (romance everyone else) this closes that separate dialogue
                    this.transform.parent.gameObject.SetActive(false);
                }
                
            }
        }
    }

    private void TextProgress()
    {
        // checks if the date dialogue and not date dialogue bools are false and if our current dialogue is less than the array length
        if (correctBool == false && wrongBool == false && Index < dialogue.Length)
        {
            // Creates a temporary script variable to be equal to the index from our main script array
            startingDialogue person = dialogue[Index];

            // Gets text colour from the current character we are talking to and override the Alpha value
            textLabel.color = new Color(person.colour.r, person.colour.g, person.colour.b, 1);

            // Calls the typewriter effect from the game object that the DialogueUI script is running on
            //and gives it the text value from our person to be printed on the textLabel
            GetComponent<TypewriterEffect>().Run(person.text, textLabel);

            // checks if our current dialogue is the one with a choice and if the buttons are off
            if (person.hasChoice == true && buttonsOn == false)
            {
                // turns the bool for the buttons on
                buttonsOn = true;
                // for loop for the length of the buttons array
                for (int i = 0; i < Buttons.Length; i++)
                {
                    // enables the buttons array with Index i
                    Buttons[i].SetActive(true);
                }
            }
            // for the Capsule, checks if button choice is disabled and we run through the dialogue
            if (Index == dialogue.Length-1 && person.hasChoice == false)
            {
                // enables the bool to close the current dialogue
                closeDial = true;
                // stops the Index variable from increasing
                StopProgress = true;
            }
        }

        // if the player chooses to date an NPC...
        if (correctBool == true)
        {
            // enables the Date dialogue path for each NPC and runs it through the typewriter
            correctChoice cor = corChoice[Index];

            textLabel.color = new Color(cor.colour.r, cor.colour.g, cor.colour.b, 1);

            GetComponent<TypewriterEffect>().Run(cor.text, textLabel);
        }
        // if the player chooses not to date an NPC...
        if (wrongBool == true)
        {
            // enables the Not Date dialogue path for each NPC and runs it through the typewriter
            wrongChoice wrong = wroChoice[Index];

            textLabel.color = new Color(wrong.colour.r, wrong.colour.g, wrong.colour.b, 1);

            GetComponent<TypewriterEffect>().Run(wrong.text, textLabel);
        }
        // check is we've run through the Date or Not Date dialogue and enables the bools to close the dialogue window
        if (Index==corChoice.Length - 1 && correctBool==true||Index==wroChoice.Length -1 && wrongBool == true)
        {
            closeDial = true;
            StopProgress = true;
        }
        // allows the index to increase if StopProgress is false
        if (StopProgress == false)
        {
            Index++;
        }

    }

    // function for the Date route activated from the UI buttons
    public void ToDate()
    {
        // checks if the typewriter is still typing
        if (TypewriterEffect.StillTyping == false)
        {
            // enables the bool for the Date choice
            correctBool = true;
            // disables the choice buttons, as the player has already chosen
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].SetActive(false);
            }
            // resets the index so that it can properly cycle through the Date route text
            Index = 0;
            // calls the TextProgress function
            TextProgress();
            // changes the character sprite to the Date sprite for each NPC
            CharImage.sprite = CharSprites[1];
            // adds to the static int of the Capsule, as he is dependent on dating everyone else first
            EnableDialogue.capsuleProgress++;
        }
    }

    // function for the Not Date route activated from the UI buttons
    public void NotToDate()
    {
        // checks if the typewriter is still typing
        if (TypewriterEffect.StillTyping == false)
        {
            // enables the bool for the Not Date choice
            wrongBool = true;
            // disables the choice buttons, as the player has already chosen
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].SetActive(false);
            }
            // resets the index so that it can properly cycle through the Not Date route text
            Index = 0;
            // calls the TextProgress function
            TextProgress();
            // changes the character sprite to the Not Date sprite for each NPC
            CharImage.sprite = CharSprites[0];

            // if you choose not to date anyone, the Capsule route becomes unavailable
        }
    }
}
