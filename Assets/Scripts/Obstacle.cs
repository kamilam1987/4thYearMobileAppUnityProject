using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    private float speed = 3f;


    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);//Object will fall down
    }

    //On collision
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerShipTag")//If tag of that object is player
        {
            
            Destroy(this.gameObject);//Destroy rock
        }//End of if 
    }
 }
