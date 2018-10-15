using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroyer : MonoBehaviour {

    //Explosion gets destroyed after animation
	void DestroyGameObject()
    {
        Destroy(gameObject);
    }//End of DestroyGameObject function
}
