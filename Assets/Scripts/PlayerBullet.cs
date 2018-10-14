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
        Vector2 position = transform.position;

        //Bullet new position
        position = new Vector2(position.x, position.y + bulletSpeed * Time.deltaTime );
        
        //Update the bullets position
        transform.position = position;

        //This is the top-right side on the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        //Destroys bullet if it's outside the screen
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);

        }

    }
}
