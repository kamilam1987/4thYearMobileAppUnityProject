using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {

    //Dclare variables
    public GameObject EnemyBullet; //Enemy bullet prefab

	// Use this for initialization
	void Start () {
        //Fires the enemy bullet after 1 second
        Invoke("FireEnemyBullet", 1f);
	}
	
    //Fires enemy bullet function
    void FireEnemyBullet() {
        //Gets a reference to the player's ship
        GameObject playerShip = GameObject.Find("PlayerShip");

        //If player is not dead
        if(playerShip != null)
        {
            //Instatntiate an enemy bullet
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);

            //Sets the bullet initial position
            bullet.transform.position = transform.position;

            //Direction towards the player's ship
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            //Sets the bullet direction
            bullet.GetComponent<EnemyBullet>().SetBulletDirection(direction);
        }


    }//End FireEnemyBullet function
}
