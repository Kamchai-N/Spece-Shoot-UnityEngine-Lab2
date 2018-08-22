using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public int hazardCount;
    public float spawnWaite;
    public Vector3 spawnValues;
    public float waveWaite;
    public float startWaite;
    public GameObject emyObj;

    public Text scoreText;
    public Text gameOverText;
    public Text restartText;

    private int score;

    private bool gameOver;
    private bool restart;

 

    void Start () {
        gameOver = false;
        restart = false;


        gameOverText.text = " ";
        restartText.text = " ";

        score = 0;
        UpdateScore();

        StartCoroutine(SpawnWaves());
        InvokeRepeating("AddEmy", 2f, 5f);
	}
    void AddEmy()
    {
        if(gameOver == false)
        {
            Vector3 spawnPsition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Instantiate(emyObj, spawnPsition, Quaternion.identity);
        }
        else
        {
            CancelInvoke("AddEmy");
        }
       
    }
    public void AddScore(int newScoreValus)
    {
        score += newScoreValus;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score : " + score.ToString();
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    void Update()
    {
        if (gameOver)
        {
            restart = true;
            restartText.text = "Press \"R\" For Restart !";
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
                // Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWaite);
        while (true)
        {
        for(int i =0; i< hazardCount; i++)
                {
                    Vector3 spawnPsition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnPotation = Quaternion.identity;
                    Instantiate(hazard, spawnPsition, spawnPotation);

                    yield return new WaitForSeconds(spawnWaite);
                }
            yield return new WaitForSeconds(waveWaite);
        }
        
        
    }
}
