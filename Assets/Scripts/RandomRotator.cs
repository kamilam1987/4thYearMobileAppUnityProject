using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
//This class is responsable for rotating asteroids
public class RandomRotator : MonoBehaviour {

    [SerializeField]
    private float speedRotate = 20f;//Rotate speed

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Rotate the asteroid
        rb.transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
    }
}//End of RandomRotator class

