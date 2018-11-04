using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RandomRotator : MonoBehaviour {

    [SerializeField]
    private float speedRotate = 20f;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        rb.transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
    }
}

