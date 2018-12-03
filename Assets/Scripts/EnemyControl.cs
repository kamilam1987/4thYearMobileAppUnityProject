using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{

    public GameObject Explosion; //Explosion prefab
    public AudioClip ExplosionSound;//Sound for explosion
    public AudioClip EnemySound;//Sound for enemy

    GameObject TextScores;//References to the score text game object
        
    //Declare Variables
    float speed; //Enemy speed
    public int points;//Points for killing enemies

    // Use this for initialization
    void Start()
    {
        //Sets the speed for Enemy
        speed = 2f;
        

        //Gets score text
        TextScores = GameObject.FindGameObjectWithTag("ScoreTextTag");

        //Sound effect on enemy show
        SoundManager.Instance.Play(EnemySound);
    }

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

    }

    //This function will trigger when there is a collision of game oject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Detects collision between enemy ship and player ship or player bullet
        if (collision.tag == "PlayerBulletTag")
        {
            //On collision detected turn on the explosion
            PlayExplosion();
            //Play explosion effect
            SoundManager.Instance.Play(ExplosionSound);
            //Destroy the enemy ship
            Destroy(gameObject);
            //Adds points for killing enemies(sets individual for each enemy)
            TextScores.GetComponent<ScoresCounter>().Score += points;
        }
    }

    //This function makes the explosion
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        //Sets position of the explosion
        explosion.transform.position = transform.position;

    }//End of PlayExplosion function

}
