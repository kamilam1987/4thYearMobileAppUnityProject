using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    //Declare Variables
    float speed;//Enemy speed

	// Use this for initialization
	void Start () {
        //Sets the speed for Enemy
        speed = 2f;
		
	}
	
	// Update is called once per frame
	void Update () {
        //Gets the Enemy current position
        Vector2 position = transform.position;

        //Enemy new position
        position = new Vector3(position.x - speed * Time.deltaTime, position.y);

        //Update the Enemy position
        transform.position = position;

        //Left side of a screen
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(-1, 0, 0));

        //Destroy Enemy if it's outside the screen
        if (transform.position.x < min.x)
        {
            Destroy(gameObject);

        }

    }
}
