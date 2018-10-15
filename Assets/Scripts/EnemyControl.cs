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
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        //Update the Enemy position
        transform.position = position;

        //Bottom-Left side of a screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //Destroy Enemy if it's outside the screen
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);

        }

    }

    //This function will trigger when there is a collision of game oject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Detects collision between enemy ship and player ship or player bullet
        if ((collision.tag == "PlayerShipTag") || (collision.tag == "PlayerBulletTag"))
        {
            //Destroy the enemy ship
            Destroy(gameObject);
        }
    }

}
