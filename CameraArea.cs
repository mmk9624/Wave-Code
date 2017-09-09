using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArea : MonoBehaviour {

    public GameObject ball;
    public Canvas GameOverCanvas; // Game Over Menu

    private CircleCollider2D ballColli; // ball collider
    private BoxCollider2D thisColli; // Camera area that ball moves in
    private float startGameDelay; // Making sure it's not game over at the start of game due to reseting scene

	// Use this for initialization
	void Start () {
        // Getting Colliders
        ballColli = ball.GetComponent<CircleCollider2D>();
        thisColli = this.gameObject.GetComponent<BoxCollider2D>();
        startGameDelay = 0;
	}
	
	// Update is called once per frame
	void Update () {
        startGameDelay += Time.deltaTime;

        // If the ball if outside camera area and it's 1 sec after the game starts, game over
        if (!thisColli.IsTouching(ballColli) && startGameDelay >= 1)
        {
            Time.timeScale = 0;
            GameOverCanvas.gameObject.SetActive(true);
        }
	}
}
