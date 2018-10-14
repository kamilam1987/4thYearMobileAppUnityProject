using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    //Declare variables
    public GameObject EnemyShip;//Enemy prefab
    float maxSpawn = 6f;
   

    // Use this for initialization
    void Start () {
        Invoke("SpawnEnemy", maxSpawn);

        //Increases spawn rate every 30seconds
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Function that spawns Enemy
    void SpawnEnemy()
    {
        //Left side of a screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        //Right side of a screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        
        //Instantiate an Enemy
        GameObject anEnemy = (GameObject)Instantiate(EnemyShip);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //Schedule when to Spawn next Enemy
        ScheduleNextSpawn();
    }

    void ScheduleNextSpawn() {
        float spawnInSeconds;
        if (maxSpawn > 1f) {
            //Picks number between 1 and maxSpawn
            spawnInSeconds = Random.Range(1f,maxSpawn);
        }
        else
        
            spawnInSeconds = 1f;
        Invoke("SpawnEnemy", spawnInSeconds);
        
    }
    //FUnction to increase dificulty in the game
    void IncreaseSpawnRate()
    {
        if (maxSpawn > 1f)
            maxSpawn--;
        if (maxSpawn == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }
}
