using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    private float speed = 3f;
    public GameObject AsteroidExplosion; //Explosion prefab
    public AudioClip ExplosionSound;//Sound for explosion
    GameObject TextScores;//References to the score text game object
    public int points;//Negative points for collision with a rock

    void Start()
    {
        //Gets score text
        TextScores = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }
   
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);//Object will fall down
        
    }

    //On collision
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerShipTag")//If tag of that object is player
        {
            //Play explosion sound effect
            SoundManager.Instance.Play(ExplosionSound);
            //Adds explosion on solision with a player
            Instantiate(AsteroidExplosion, transform.position,transform.rotation);
            //Takes away points for collision 
            TextScores.GetComponent<ScoresCounter>().Score -= points;
            Destroy(this.gameObject);//Destroy rock
         }//End of if 
    }

   

}
