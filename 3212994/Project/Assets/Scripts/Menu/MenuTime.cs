using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTime : MonoBehaviour
{

    private bool pauseTrack;
    private CameraController camStop;
    private CharacterController charaStop;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        // Finds an object with the camera controller script in the scene
        camStop = Object.FindObjectOfType<CameraController>();
        // Finds an object with the character controller script in the scene
        charaStop = Object.FindObjectOfType<CharacterController>();
        // checks if the typewriter is still typing and makes sure it is off to start with
        TypewriterEffect.StillTyping = false;
        // the Capsule's initial dialogue is reset to 0
        EnableDialogue.capsuleProgress = 0;
        // disables the bool for tracking the player's capsule progress
        EnableDialogue.enabledSecondDialogue = false;
    }

    // Update is called once per frame
    void Update()
    {
        // checks for escape input and if a pause menu is assigned to the scene
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu)
        {
            // runs the pause menu function
            PauseGame();
        }
    }

    public void Quit()
    {
        // quits the application if run
        Application.Quit();
    }

    public void StartGame(string dateLevel)
    {
        // loads the scene based on the string that the fuction gives it
        SceneManager.LoadScene(dateLevel);
    }

    public void PauseGame()
    {
        // if the bool to track if paused is true...
        if (pauseTrack)
        {
            // disables the pause menu panel
            pauseMenu.SetActive(false);
            // enables the character controller
            charaStop.enabled = true;
            // enables the camera controller
            camStop.enabled = true;
            // hides the mouse
            Cursor.visible = false;
            // locks the mouse in game view
            Cursor.lockState = CursorLockMode.Locked;
            // sets the pause tracking bool to false
            pauseTrack = false;
        }
        // if the game is paused...
        else
        {
            // enables the pause menu panel
            pauseMenu.SetActive(true);
            // disables the character controller, freezing the character in place
            charaStop.enabled = false;
            // disables the camera controller, preventing looking around
            camStop.enabled = false;
            // makes the mouse visible on screen
            Cursor.visible = true;
            // unlockes the mouse from game view
            Cursor.lockState = CursorLockMode.None;
            // sets the pause tracking bool to true
            pauseTrack = true;
        }
    }
}
