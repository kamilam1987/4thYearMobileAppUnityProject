using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour {

    //Declare variables
    private AudioSource audioSrc;//Reference to Audio Source component
    private float musicVolume = 1f;//Music volume
	// Use this for initialization
	void Start () {
        //Assign Audo Source component to control it
        audioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //Setting volume option of Audio Source to equal to music volume
        audioSrc.volume = musicVolume;
    }
    //SetVolume method takes vol value passed by slider and sets it to musicValue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
