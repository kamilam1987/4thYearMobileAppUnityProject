using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class is responsable for storing and counting points in a game
public class ScoresCounter : MonoBehaviour {

    //Declare variables
    Text TextScores;//score text
    public static int score;//Scores counter

    //Score method counts the points
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            UpdateScores();
        }
    }//End of Score method

    // Use this for initialization
     void Start () {
        score = 0;
        //Gets the text component of this game object
        TextScores = GetComponent<Text>();
    }

    //This function updates the score text
     void UpdateScores()
    {
        if (score < 0) {
            score = 0;
        }
        TextScores.text = score.ToString();
    }
}//End of ScoreCounter class
