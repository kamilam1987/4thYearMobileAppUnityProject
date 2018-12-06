using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class controls a new game menu
public class NewGameFunctionality : MonoBehaviour {

    public GameObject TimeCounter;//References to the time counter game object
    public GameObject newGame;//Refer to credits panel display

    //On TimeAttackButton click
    public void TimeAttackButton()
    {
        TimeCounter.GetComponent<TimeCounter>().StartTimeCounter();
        //Load time attack scene where player has a 1 life and time counter 
        SceneManager.LoadScene(4);
        Time.timeScale = 1;//Start time
        
    }

    //On ScoreChaseButton click
    public void ScoreChaseButton()
    {
        //Load Score Chase mode where player has a 3 lifes 
        SceneManager.LoadScene(1);
        Time.timeScale = 1;//Starts time
    }

    //On SurvivalButton click
    public void SurvivalButton()
    {   //Load Score Chase mode where player has only 1 life
        SceneManager.LoadScene(3);
        Time.timeScale = 1;//Starts time
    }

    //On SurvivalButton click
    public void BackButton()
    {
        //Display Main Menu 
        SceneManager.LoadScene(0);
        //Hide new game menu
        newGame.SetActive(false);
    }
}//End of NewGameFunctionality class
