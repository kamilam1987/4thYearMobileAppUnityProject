using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour {

    //Declare variables
    public GameObject asteroid;// Asteroid prefab
    public Vector3 spawnValues;// Values for asteroid position
    void Start()
    {
        SpawnWaves();
    }

    void SpawnWaves()
    {
        //Sets asteroid spawn position
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(asteroid, spawnPosition, spawnRotation);
    }
}
