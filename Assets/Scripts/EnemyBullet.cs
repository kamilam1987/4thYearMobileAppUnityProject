using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    //Declare variables
    float bulletSpeed; //The bullet speed
    Vector2 bulletDirection; //The dorection of a bullet
    bool isReady; //To know when the bullet direction is set

    //Sets default values in Awake function
    private void Awake()
    {
        bulletSpeed = 5f;
        isReady = false;
    }

    //This function sets the bullet's direction
    public void SetBulletDirection(Vector2 direction)
    {
        //Sets the direction normalized, to get an unit vector
        bulletDirection = direction.normalized;
        //Sets to true
        isReady = true;
    }//End of SetBulletDirection function

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isReady)
        {
            //Gets the current position of a bullet
            Vector2 position = transform.position;

            //Sets the bullet new position
            position += bulletDirection * bulletSpeed * Time.deltaTime;

            //Updates the new position
            transform.position = position;

            //The bottom-left point on the screen
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            //The top-right point on the screen
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            //Destroy bullet if will go outside the screen
            if ((transform.position.x < min.x) || (transform.position.x > max.x) || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Detects collision between enemy bullet and player ship 
        if ((collision.tag == "PlayerShipTag"))
        {
            //Destroy the enemy bullet
            Destroy(gameObject);
        }
    }
}
