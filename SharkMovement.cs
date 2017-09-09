using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMovement : MonoBehaviour {

    public float speed; // shark's movement speed
    public GameObject ball; 
    public Canvas GameOverCanvas; // Game Over Menu

    private Vector3 leftDestination; // the leftest position that shark can travel to
    private Vector3 rightDestination; // the rightest position that shark can travel to
    private Vector3 Destination; // current destination that shark is travelling to 
    private BoxCollider2D sharkCollider; 
    private CircleCollider2D ballCollider;

	// Use this for initialization
	void Start () {
        // Getting colliders
        sharkCollider = this.gameObject.GetComponent<BoxCollider2D>();
        ballCollider = ball.GetComponent<CircleCollider2D>();

        // Setting destinations
        rightDestination = new Vector3(2.11f, this.gameObject.transform.position.y, -0.01f);
        leftDestination = new Vector3(-1.6f, this.gameObject.transform.position.y, -0.01f);
        speed = 0.5f;

        Destination = rightDestination;
    }
	
	// Update is called once per frame
	void Update () {
        // Game Over if ball touches shark
        if (sharkCollider.IsTouching(ballCollider))
        {
            Time.timeScale = 0;
            GameOverCanvas.gameObject.SetActive(true);
        }

        // move to the opposite destination when reach one, otherwise move towards current destination
        if (Vector3.Distance(transform.position, rightDestination) == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            Destination = leftDestination;
        }
        else if (Vector3.Distance(transform.position, leftDestination) == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Destination = rightDestination;
        }
        transform.position = Vector3.MoveTowards(transform.position, Destination, speed * Time.deltaTime);    
	}
}
