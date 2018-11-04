using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PauseButton : MonoBehaviour {

    //Declare variables
    public Button pauseButton;
    public Sprite pause1;
    public Sprite play;
    private int counter = 0;

    // Use this for initialization
    void Start () {

        pauseButton = GetComponent<Button>();
	}
	
	public void changeButton()
    {
        counter++;
        if(counter % 2 == 0)
        {
            pauseButton.image.overrideSprite = pause1;
            Time.timeScale = 1;
            AudioListener.pause = false;

        }
        else
        {
            pauseButton.image.overrideSprite = play;
            Time.timeScale = 0;
            AudioListener.pause = true;

        }
    }
   
}
