using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

    //Declare variables
    public GameObject pauseObj;//Pause object
    private float tempTimeScale;//Value for time scale when pause is on(stops the game)

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

    }
    //On Quit Button click
    public void QuitButton()
    {
        //Starts time
        Time.timeScale = 1;
        //Exit game
        Application.Quit();
    }



}
