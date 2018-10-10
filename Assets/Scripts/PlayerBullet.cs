using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    //Declare variable
    float bulletSpeed;

	// Use this for initialization
	void Start () {
        bulletSpeed = 6f;
	}
	
	// Update is called once per frame
	void Update () {
        //Gets the bullets current position
        Vector3 position = transform.position;

        //Bullet new position
        position = new Vector3(position.x + bulletSpeed * Time.deltaTime, position.y );
        
        //Update the bullets position
        transform.position = position;

        //This is the right point on the screen
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1,0, 0));

        //Destroys bullet if it's outside the screen
        if (transform.position.x > max.x)
        {
            Destroy(gameObject);

        }

    }
}
