using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameFunctionality : MonoBehaviour {

    //On TimeAttackButton click
    public void TimeAttackButton()
    {
       // SceneManager.LoadScene(0);
    }

    //On ScoreChaseButton click
    public void ScoreChaseButton()
    {
        //Load Score Chase mode where player has a 3 lifes 
        SceneManager.LoadScene(1);
    }

    //On SurvivalButton click
    public void SurvivalButton()
    {   //Load Score Chase mode where player has only 1 life
        SceneManager.LoadScene(3);
    }
}
