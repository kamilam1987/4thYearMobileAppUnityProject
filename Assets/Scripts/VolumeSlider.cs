using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is responsable for changing music effects volume
public class VolumeSlider : MonoBehaviour {

    //Declare variables
    private AudioSource audioSrc;//Reference to Audio Source component
    private float musicVolume = 1f;//Music volume
	// Use this for initialization
	void Start () {
        //Assign Audo Source component to control it
        audioSrc = GetComponent<AudioSource>();
	}//End of Start method
	
	// Update is called once per frame
	void Update () {
        //Setting volume option of Audio Source to equal to music volume
        audioSrc.volume = musicVolume;
    }//End of Update method

    //SetVolume method takes vol value passed by slider and sets it to musicValue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }//End of SetVolume function
}//End of VolumeSlider class
