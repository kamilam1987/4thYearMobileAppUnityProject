using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//References:https://www.youtube.com/watch?v=rQXvDDoXvLo&t=2s

// This class controlls enemy behaviour
public class EnemyControl : MonoBehaviour
{
    //Declare variabes
    float speed; //Enemy speed
    public int points;//Points for killing enemies

    public GameObject Explosion; //Explosion prefab
    public AudioClip ExplosionSound;//Sound for explosion
    public AudioClip EnemySound;//Sound for enemy
    GameObject TextScores;//References to the score text game object
        
    // Use this for initialization
    void Start()
    {
        //Sets the speed for Enemy
        speed = 2f;
        
        //Gets score text
        TextScores = GameObject.FindGameObjectWithTag("ScoreTextTag");

        //Sound effect on enemy show
        SoundManager.Instance.Play(EnemySound);
    }//End of Start function

    // Update is called once per frame
    void Update()
    {
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

    }//End of Update function

    //This function will trigger when there is a collision of game oject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Detects collision between enemy ship and player ship or player bullet
        if (collision.tag == "PlayerBulletTag")
        {
            //On collision detected turn on the explosion
            PlayExplosion();
            //Play explosion sound effect
            SoundManager.Instance.Play(ExplosionSound);
            //Destroy the enemy ship
            Destroy(gameObject);
            //Adds points for killing enemies(sets individual for each enemy)
            TextScores.GetComponent<ScoresCounter>().Score += points;
        }
    }//End of OnTriggerEnter2D function

    //This function makes the explosion
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        //Sets position of the explosion
        explosion.transform.position = transform.position;

    }//End of PlayExplosion function

}//End of EnemyControl class
