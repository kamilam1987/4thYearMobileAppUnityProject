using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresCounter : MonoBehaviour {

    //Declare variables
    Text TextScores;
    int score;//Scores counter

    //Score method counts the points
    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScores();
        }
    }//End of Score method

    // Use this for initialization
    void Start () {
        //Gets the text component of this game object
        TextScores = GetComponent<Text>();
	}

    //This function updates the score text
    private void UpdateScores()
    {
        TextScores.text = score.ToString();
    }

}
