using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gmaeController;
    public int ScoreValue;


    // Use this for initialization
    void Start () {
        GameObject gmaeControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if(gmaeControllerObject != null)
        {
            gmaeController = gmaeControllerObject.GetComponent<GameController>();
        }

        if(gmaeControllerObject == null)
        {
            Debug.Log("Cannot Find 'CmaeController' Script");
        }
    }
	
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boudary")
        {
            return;
        }

        if(other.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(playerExplosion, other.transform.position,other.transform.rotation);
            gmaeController.GameOver();

            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if (other.tag == "Bolt")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            gmaeController.AddScore(ScoreValue);    
        }
    }
}
