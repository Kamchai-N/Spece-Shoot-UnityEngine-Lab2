using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmyController : MonoBehaviour {
    public float speed;
    GameObject player;
    private Rigidbody rb;
    public float tilt;
    public GameObject emyBolt;
    public float timeStartShooting;
    public float timeLoopShooting;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("OnShooting", timeStartShooting, timeLoopShooting);
	}

    void OnShooting()
    {
        Instantiate(emyBolt, transform.position, Quaternion.identity);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(player != null)
        {
            float moveX = 0f;

            if (Mathf.Round(player.transform.position.x) > Mathf.Round(transform.position.x))
            {
                moveX = 1f;
            }else if (Mathf.Round(player.transform.position.x) < Mathf.Round(transform.position.x))
            {
                moveX = -1f;
            }
            rb.velocity = new Vector3(moveX, 0f, -1f);
            rb.rotation = Quaternion.Euler(0f, 180f, rb.velocity.x * tilt);
        }
	}
}
