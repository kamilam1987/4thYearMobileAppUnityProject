using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is responsable to controll moving background
public class BackgroundController : MonoBehaviour {

    public float scrollSpeed; //Speed for background scrolling
    private Vector2 offset;
	
	// Update is called once per frame
	void Update () {
        offset = new Vector2(0,Time.time * scrollSpeed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;//Gets component from object which script is assigned to, assigne offset to object texture
    }//End of Update 
}// End of BackgroundController class
