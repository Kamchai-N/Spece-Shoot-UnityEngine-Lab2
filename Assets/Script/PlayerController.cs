using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    public Boundary boundary;
    public float titl;

    public GameObject shot;
    public Transform shortSpawn;

    public float freRate;
    private float nextFire;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
            //x
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.zMax),
            //y
            0.0f,
            //z
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x*-titl);
	}
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + freRate;
            Instantiate(shot, shortSpawn.position, shortSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
}
