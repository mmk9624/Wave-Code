using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    public GameObject Background1; 
    public GameObject Background2;
    public GameObject Background3;
    public GameObject ball;
    public GameObject shark;
    public Canvas pauseCanvas;

    private float threshold;
    private int tileCount;

	// Use this for initialization
	void Start () {
        // Setting initial values
        tileCount = 3;
        threshold = 40.96f;
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        // If the ball pass the current threshold, instantiate double amount of the tile
		if (ball.transform.position.y >= threshold)
        {
            for (int i = tileCount; i < 2 * tileCount; i++)
            {
                // Create random number to determine the background to use for this tile
                float bgNumber = Random.Range(1, 4);
                if (bgNumber == 1)
                {
                    Instantiate(Background1, new Vector3(0, i * 20.48f, 0), Quaternion.Euler(0, 0, 0));
                }
                else if (bgNumber == 2)
                {
                    Instantiate(Background2, new Vector3(0, i * 20.48f, 0), Quaternion.Euler(0, 0, 0));
                }
                else
                {
                    Instantiate(Background3, new Vector3(0, i * 20.48f, 0), Quaternion.Euler(0, 0, 0));
                }

                float randomPos = Random.Range(-9, 10);
                Instantiate(shark, new Vector3(0, i * 20.48f + randomPos, 0), Quaternion.Euler(0, 0, 0));
            }

            // Update values
            tileCount = 2 * tileCount;
            threshold = (tileCount - 1) * 20.48f - 10.24f;
        }
	}

    // When Pause button is clicked
    public void onClickPause()
    {
        Time.timeScale = 0;
        pauseCanvas.gameObject.SetActive(true);
    }

    // When Resume button is clicked
    public void onClickResume()
    {
        Time.timeScale = 1;
        pauseCanvas.gameObject.SetActive(false);
    }

    // When Retry button is clicked
    public void onClickRetry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("WaveMain");
    }
}
