using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour {

    //Declare variables
    public GameObject pauseObj;//Pause object
    private float tempTimeScale;//Value for time scale when pause is on(stops the game)
    public GameObject pauseMenuHolder;
    public GameObject optionsMenuHolder;


    public Toggle[] resolutionToggles;
    public Toggle fullscreenToggle;
    public int[] screenWidths;
    int activeScreenResIndex;

    void Start()
    {
        activeScreenResIndex = PlayerPrefs.GetInt("screen res index");
        bool isFullscreen = (PlayerPrefs.GetInt("fullscreen") == 1) ? true : false;



        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].isOn = i == activeScreenResIndex;
        }

        //Need to be fix
        //fullscreenToggle.isOn = isFullscreen;
    }

    void Update()
    {
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
        Time.timeScale = 1;
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


    public void SetScreenResolution(int i)
    {
        if (resolutionToggles[i].isOn)
        {
            activeScreenResIndex = i;
            float aspectRatio = 16 / 9f;
            Screen.SetResolution(screenWidths[i], (int)(screenWidths[i] / aspectRatio), false);
            PlayerPrefs.SetInt("screen res index", activeScreenResIndex);
            PlayerPrefs.Save();
        }
    }
    public void SetFullScreen(bool isFullscreen)
    {
        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].interactable = !isFullscreen;
        }

        if (isFullscreen)
        {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions[allResolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }
        else
        {
            SetScreenResolution(activeScreenResIndex);
        }
        PlayerPrefs.SetInt("fullscreen", ((isFullscreen) ? 1 : 0));
        PlayerPrefs.Save();
    }


}
