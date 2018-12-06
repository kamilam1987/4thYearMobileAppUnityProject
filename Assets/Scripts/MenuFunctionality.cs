using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class controls main menu
public class MenuFunctionality : MonoBehaviour {

    public GameObject highScore;//Refer to leaderboar panel display
    public GameObject menu;//Refer to main menu panel display
    public GameObject credits;//Refer to credits panel display
    public GameObject instruction; //Refer to instruction panel display

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
        //Load scene with new game menu
        SceneManager.LoadScene(2);
    }

    //On ContinueButton click
    public void InstructionButton()
    {
        //Hide Main Menu 
        GameObject.Find("Menu").SetActive(false);
        //Display High Scores
        instruction.SetActive(true);
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
        GameObject.Find("Menu").SetActive(false);
        //Display High Scores
        credits.SetActive(true);
    }

    //On LeaveButton click
    public void LeaveButton()
    {
        //Quit the game
        Application.Quit();
    }

    //On Back Button click in leaderboard panel
    public void BackButton()
    {
        //Display Main Menu 
        menu.SetActive(true);
        //Hide High Scores
        highScore.SetActive(false);
    }

    //On Back Button click in credits panel
    public void BackButtonCredits()
    {
        //Display Main Menu 
        menu.SetActive(true);
        //Hide credits board
        credits.SetActive(false);
    }

    //On Back Button click in instruction panel
    public void BackButtonInstruction()
    {
        //Display Main Menu 
        menu.SetActive(true);
        //Hide instruction panel
        instruction.SetActive(false);
    }
}//End MenuFunctionality class
