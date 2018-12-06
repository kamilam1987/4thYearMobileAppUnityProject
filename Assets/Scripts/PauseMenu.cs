using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//References: https://www.youtube.com/watch?v=EA-tBcTxE8M
//This class controls pause menu 
public class PauseMenu : MonoBehaviour {

    //Declare variables
    public GameObject pauseObj;//Pause object
    private float tempTimeScale;//Value for time scale when pause is on(stops the game)
    public GameObject pauseMenuHolder;//Object for pause menu
    public GameObject optionsMenuHolder;//Object for option menu

    //Create array to store diffrent resolution setting
    public Toggle[] resolutionToggles;
    public Toggle fullscreenToggle;
    public int[] screenWidths;
    int activeScreenResIndex;

    void Start()
    {
        //Sets resolution current index 
        activeScreenResIndex = PlayerPrefs.GetInt("screen res index");
        //Checks if is set to full screen
        bool isFullscreen = (PlayerPrefs.GetInt("fullscreen") == 1) ? true : false;

        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            //Check screen resolution index
            resolutionToggles[i].isOn = i == activeScreenResIndex;
        }
    }//End of Start method

    void Update()
    {
        //Press esc to pasue the game
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Time.timeScale != 0)
            {
                tempTimeScale = Time.timeScale;
            }//End of if
            PauseGame();//Runs pause method
        }//End of if
    }//End of Update method

    //Stops the game
    void PauseGame()
    {
        pauseObj.SetActive(!pauseObj.activeInHierarchy);//If active in hierrarhy deaactivate pause
        if (Time.timeScale != 0)//If it's not 0
        {
            Time.timeScale = 0;//Assigned 0 to the time scale
        }//End of if
        else
        {
            Time.timeScale = tempTimeScale;
        }//End of else

    }//End of PauseGame method

    //On Resume Button click
    public void ResumeButton()
    {
        PauseGame();
    }
    //On Restart Button click
    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    //On Options Button click
    public void OptionsButton()
    {
        pauseMenuHolder.SetActive(false);
        optionsMenuHolder.SetActive(true);
    }
    //On Quit Button click
    public void QuitButton()
    {
        //Starts time
        Time.timeScale = 0;
        //Exit game
        Application.Quit();
    }
    //On Back Button click
    public void BackButton()
    {
        //Starts time
        Time.timeScale = 0;
        
        pauseMenuHolder.SetActive(true);
        optionsMenuHolder.SetActive(false);
    }

    //Sets screen resolution method
    public void SetScreenResolution(int i)
    {
        if (resolutionToggles[i].isOn)
        {
            //Checks the current index and sets the scrren resolution
            activeScreenResIndex = i;
            float aspectRatio = 16 / 9f;
            Screen.SetResolution(screenWidths[i], (int)(screenWidths[i] / aspectRatio), false);
            PlayerPrefs.SetInt("screen res index", activeScreenResIndex);
            PlayerPrefs.Save();
        }
    }
    //Sets full screen method
    public void SetFullScreen(bool isFullscreen)
    {
        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            //Checks if the full screen is pressed
            resolutionToggles[i].interactable = !isFullscreen;
        }

        if (isFullscreen)
        {
            //Sets resolution for full screen
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions[allResolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }
        else
        {
            SetScreenResolution(activeScreenResIndex);
        }
        //Saves player setting
        PlayerPrefs.SetInt("fullscreen", ((isFullscreen) ? 1 : 0));
        PlayerPrefs.Save();
    }

}//End of PauseMenu class
