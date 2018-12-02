using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameFunctionality : MonoBehaviour {

    public GameObject TimeCounter;//References to the time counter game object

    //On TimeAttackButton click
    public void TimeAttackButton()
    {
        TimeCounter.GetComponent<TimeCounter>().StartTimeCounter();
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
        
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
}
