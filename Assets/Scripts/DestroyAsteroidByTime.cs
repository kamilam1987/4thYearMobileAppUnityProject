using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is responsable for destroying asteroids 
public class DestroyAsteroidByTime : MonoBehaviour {

    //Declare variables
    public float lifeTime; //Refers life time for asteroid

	// Use this for initialization
	void Start () {
        //Destroy itself when the time is up
        Destroy(gameObject, lifeTime);
	}//End of Start method

}//End of DestroyAsteroidByTime class
