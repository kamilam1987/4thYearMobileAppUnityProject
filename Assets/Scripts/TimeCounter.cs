using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class displays and sets the timer
public class TimeCounter : MonoBehaviour {

    //Declare variables
    Text time; //References to the time counter UI Text
    float startTime; // The time when the user clicks on Time Attack
    float ellapsedTime; // The ellapsed time after the user clicks on Time Attack
    bool startCounter; // Flag to start the counter
    int minutes;
    int seconds;

    // Use this for initialization
    void Start () {
        startTime = 0;
        startCounter = false;
        // Gets the Text UI component from this gameObcject
        time = GetComponent<Text>();
	}

    //Function to start the time counter
    public void StartTimeCounter() {
        startTime = Time.time;
        startCounter = true;
    }

    //Funtion to stop time counter
    public void StopTimeCounter() {
        startCounter = false;
    }
	// Update is called once per frame
	void Update () {
        if (startCounter)
        {
            //Computes the ellapsed time
            ellapsedTime = Time.time - startTime;
            //Gets the minutes
            minutes = (int)ellapsedTime / 60;
            //Gets the seconds
            seconds = (int)ellapsedTime % 60;

            //Updates the counter UI Text
            time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
	}//End of Update method

}//End of TimeCounter class
