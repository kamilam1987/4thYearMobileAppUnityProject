using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
//Controls pause in game when pressed pause image
public class PauseButton : MonoBehaviour {

    //Declare variables
    public Button pauseButton;// Pause button
    public Sprite pause1;//Image of pause button
    public Sprite play;//Image of play button
    private int counter = 0;

    // Use this for initialization
    void Start () {
        //Get button component
        pauseButton = GetComponent<Button>();
	}//End of Start method
	
    //On pause button press
	public void changeButton()
    {
        counter++;
        if(counter % 2 == 0)
        {
            //If not pressed then display pause image
            pauseButton.image.overrideSprite = pause1;
            Time.timeScale = 1;//Game plays
            //Display play image
            AudioListener.pause = false;
        }
        else
        {
            //If pause image pressed then change image to play
            pauseButton.image.overrideSprite = play;
            Time.timeScale = 0;//Stops game
            //Display pause image
            AudioListener.pause = true;

        }
    }//End of changeButton method
}//End of PauseButton class
