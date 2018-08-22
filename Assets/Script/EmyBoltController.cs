using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmyBoltController : MonoBehaviour {
    public GameObject playerExplosion;
    private GameController gmaeController;
    // Use this for initialization
    void Start()
    {
        GameObject gmaeControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gmaeControllerObject != null)
        {
            gmaeController = gmaeControllerObject.GetComponent<GameController>();
        }

        if (gmaeControllerObject == null)
        {
            Debug.Log("Cannot Find 'CmaeController' Script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gmaeController.GameOver();

            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }
}
