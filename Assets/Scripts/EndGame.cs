using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    //Declare Variables
    public Text totalPoints;

	// Use this for initialization
	void Start () {
        //Gest scores from ScoresCounter class
        totalPoints.text = ScoresCounter.score.ToString();
    }
    void Update()
    {
        //Calculate the total points for the game over screen
        totalPoints.text = int.Parse(totalPoints.text).ToString();
    }

    // On Return button click 
    public void ReturnButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    
        
    

}
