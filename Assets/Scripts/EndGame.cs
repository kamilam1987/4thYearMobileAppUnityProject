using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Reference : https://www.youtube.com/watch?v=xlJ4IgjiTXc

//This class is responsable for displaying game over screen
public class EndGame : MonoBehaviour {

    //Declare Variables
    public Text totalPoints; //Total score at the end of a screen
    private int score;//For checking high score
    private int[] highScoresArray = new int[10];// Array with ten high scores

	// Use this for initialization
	void Start () {
        //Gets high score array 
        highScoresArray = PlayerPrefsX.GetIntArray("HighScoreArray");
        //Gest scores from ScoresCounter class
        totalPoints.text = ScoresCounter.score.ToString();
        //Calculate the total points for the game over screen
        totalPoints.text = int.Parse(totalPoints.text).ToString();
        //Parses points to int
        score = int.Parse(totalPoints.text);
        //Checks if the score is higher then the last element in the array
        if (score > highScoresArray[9])
        {
            for (int i = 0; i < 10; i++)//Loops the array to add a high score
            {
                if (score > highScoresArray[i])//Check if score is higher then the pleace in array that is in
                {
                    for (int j = 9; j > i; j--)//Scores go down by one in the array
                    {
                        highScoresArray[j] = highScoresArray[j - 1];
                    }//End of for
                    highScoresArray[i] = score;//Found the pleace in the array
                    break;//Found the pleace so it won't look for more
                }//End of if
            }//End of for loop

        }//End of if

        PlayerPrefsX.SetIntArray("HighScoreArray", highScoresArray);//Adds result to the high score array
    }//End of start method
    
    // On Return button click 
    public void ReturnButton()
    {
        Time.timeScale = 1;
        //Load Main menu
        SceneManager.LoadScene(0);
    }

    //On quit button press
    public void QuitButton()
    {   //Close application
        Application.Quit();
    }

}//End of EndGame class
