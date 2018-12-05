using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctionality : MonoBehaviour {

    public GameObject highScore;//Display leader board
    public GameObject menu;//Display main menu 


    void Start()
    {
        if (PlayerPrefsX.GetIntArray("HighScoreArray", 0, 10)[0] == 0) //takes 3 arguments(name, the default values has to assigned if it's not in the system and the default size of array), if the first element is 0 crate this array
        {
            int[] hightScoresinitializationArray = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };//Array that keeps 10 of highest scores(sets them all to 0 at the start)
                                                                                                //Assigned a whole array of int numbers
            PlayerPrefsX.SetIntArray("HighScoreArray", hightScoresinitializationArray);//Takes two arguments(name and array)
        }//End of if
    }//End of Start method

    //On NewGameButton click
    public void NewGameButton()
    {
        Time.timeScale = 1;//Starts time
        SceneManager.LoadScene(2);
    }

    //On ContinueButton click
    public void InstructionButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }

    //On LeaderBoardButton click
    public void LeaderBoardButton()
    {
        //Hide Main Menu 
        GameObject.Find("Menu").SetActive(false);
        //Display High Scores
        highScore.SetActive(true);

    }

    //On CreditsButton click
    public void CreditsButton()
    {
        // SceneManager.LoadScene(0);
    }

    //On LeaveButton click
    public void LeaveButton()
    {
        //Quit the game
        Application.Quit();
    }

    //On BackButton click
    public void BackButton()
    {
        //Display Main Menu 
        menu.SetActive(true);
        //Hide High Scores
        highScore.SetActive(false);
    }
}
