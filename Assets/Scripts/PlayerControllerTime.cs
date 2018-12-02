using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerTime : MonoBehaviour {

    public GameObject PlayerShipBullet;//Bullets prefab
    public GameObject BulletPosition;//Position of a bullet
    public GameObject Explosion;//Explosion prefab
    public AudioClip ExplosionSound;//Sound for explosion
    public GameObject EnemySpawner;
    public GameObject AsteroidSpawner;
    public GameObject EndGameScreen;// Game over screen
    public GameObject TimeCounter;//References to the time counter game object

    //Declare variables
    public float speed;//Speed of player ship
    public Text TextLives; //Reference to the lives UI text
    const int MaxLives = 1;//Max player lives
    int lives; //Current player lives
    public float timeLeft = 0f;
    GameObject TextScores;//References to the score text game object
    public int points;//Negative points for collision with a rock

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        lives = MaxLives;
        //Updates the lives UI text
        TextLives.text = lives.ToString();
        
        //Sets this game object to active
        gameObject.SetActive(true);
        //Starts time counter
        TimeCounter.GetComponent<TimeCounter>().StartTimeCounter();
        //Gets score text
        TextScores = GameObject.FindGameObjectWithTag("ScoreTextTag");
        
        
    }
    // Update is called once per frame
    void Update()
    {
        //timeCheck();
        Debug.Log(timeLeft);
        //timeLeft += Time.deltaTime;
        //On spacebar press fires the bullets
        if (Input.GetKeyDown("space"))
        {
            //Instantioate bullet
            GameObject bullet = (GameObject)Instantiate(PlayerShipBullet);
            //Sets initial bullet position
            bullet.transform.position = BulletPosition.transform.position;

        }
        float x = Input.GetAxisRaw("Horizontal");//The value will be -1(left), 0(no inpit), or 1(right)
        float y = Input.GetAxisRaw("Vertical");//The value will be -1(down), 0(no inpit), or 1(up)

        //Compute a direction vector and normalize to get a unit vector
        Vector2 direction = new Vector2(x, y).normalized;

        //Call Move function 
        Move(direction);
        
    }
    //Move function sets the player position
    void Move(Vector2 direction)
    {
        //Finds the screen limits to the players movement(edges on the screen)
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//Bottom-left point on the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//Top-right point on the screen

        max.x = max.x - 0.5f;//Substract the player sprite half width
        min.x = min.x + 0.5f;//Add the player sprite half width

        max.y = max.y - 0.85f;//Substract the player sprite half height
        min.y = min.y + 0.85f;//Add the player sprite half height

        //Gets the player current position
        Vector2 pos = transform.position;

        //Calculate the new position
        pos += direction * speed * Time.deltaTime;

        //Makes sure that the new psition is not outside the screen
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //Update the players position
        transform.position = pos;

    }

    //This function will trigger when there is a collision of game oject
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Detects collision between player ship and enemy ship or enemy bullet
        if ((collision.tag == "EnemyShipTag") || (collision.tag == "EnemyBulletTag"))
        {
            //On collision detected turn on the explosion
            PlayExplosion();
            SoundManager.Instance.Play(ExplosionSound);
            //Subtract one live
            lives--;
            //updates lives UI text
            TextLives.text = lives.ToString();
           
            if (lives == 0)
            {
                //Destroy the player ship
                //Destroy(gameObject);
                gameObject.SetActive(false);
                Destroy(EnemySpawner);
                Destroy(AsteroidSpawner);
                EndGameScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }


    /*public void timeCheck() {
        
        //If timeout
        if (timeLeft >= 10f)
        {
            //Destroy the player ship
            //Destroy(gameObject);
            gameObject.SetActive(false);
            Destroy(EnemySpawner);
            Destroy(AsteroidSpawner);

            //Stop the time counter
            TimeCounter.GetComponent<TimeCounter>().StopTimeCounter();
            EndGameScreen.SetActive(true);
            Time.timeScale = 0;
            timeLeft = 0;

        }
        
    }*/

    //This function makes the explosion
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        //Sets position of the explosion
        explosion.transform.position = transform.position;

    }//End of PlayExplosion function
}
