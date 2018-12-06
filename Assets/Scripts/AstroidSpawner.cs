using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code adapted from: https://unity3d.com/learn/tutorials/projects/space-shooter/spawning-waves

//This class is responsible for the asteroid spawner
public class AstroidSpawner : MonoBehaviour {

    //Declare variables
    public GameObject asteroid;// Asteroid prefab
    public Vector3 spawnValues;// Values for asteroid position
    public int asteroidCount; //Counter for amount of asteroids
    public float spawnWait; //Amount of time between spawn
    public float startWait; //Time for pause 
    public float waveWait; //Time to wait between waves

    void Start()
    {
        //Call SpawnWave function this ia a short pause for player to get ready
        StartCoroutine(SpawnWaves());
    }

    // This method defind how offten the asteroid will spawn
    //Coroutine function
    IEnumerator SpawnWaves()
    {
        //Waits a few seconds to start spawn
        yield return new WaitForSeconds(startWait);
        while (true) { 
            for (int i = 0; i < asteroidCount;i++) { 
                //Sets asteroid spawn position
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(asteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            //Create gaps between waves
            yield return new WaitForSeconds(waveWait);
        }//End while loop
    }//End SpawnWavesfunction
}//End AstroidSpawner class
