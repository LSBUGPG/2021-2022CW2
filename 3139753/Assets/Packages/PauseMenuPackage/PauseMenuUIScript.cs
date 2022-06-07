using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUIScript : MonoBehaviour
{
    public GameObject PauseMenuBG;
    public GameObject PauseMenuUI;

    public static bool GameIsPaused = false;
    public GameObject Cams;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Return();

            }
            else
            {
                Pause();
            }

        }
    }


   public void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Debug.Log("Game is paused...");

        Cams.GetComponent<CanvasGroup>().alpha = 0f;
        PauseMenuUI.SetActive(true);
        PauseMenuBG.SetActive(true);

        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Return()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Cams.GetComponent<CanvasGroup>().alpha = 1f;
        PauseMenuUI.SetActive(false);
        PauseMenuBG.SetActive(false);

        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Resuming...");
    }


    public void StageSelect()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        //STAGE SELECT SCENE VALUE
        //CHANGE SCENE NUMBER TO THAT OF YOUR MAIN MENU
        SceneManager.LoadScene(0);

        Debug.Log("Loading stage select...");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restarting level...");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
