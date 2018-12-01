using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    //Declare Variables
    public Text totalPoints;

	// Use this for initialization
	void Start () {
        totalPoints.text = ScoresCounter.score.ToString();
       
        //totalPoints.text = int.Parse(totalPoints.text).ToString();
    }
    void Update()
    {
        totalPoints.text = int.Parse(totalPoints.text).ToString();
    }

}
