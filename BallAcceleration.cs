using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallAcceleration : MonoBehaviour {

    public float acceleration;
    public Text scoreText; // Text element to display the score

	// Use this for initialization
	void Start () {
        // Initial value
        acceleration = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
        // Giving the ball a continuous force to make it acceleration
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, acceleration));

        // Update Score text
        if (this.gameObject.transform.position.y >= 0)
        {
            scoreText.text = this.gameObject.transform.position.y.ToString("0.0") + "m";
        }
        else
        {
            // Prevent negative value being displayed
            scoreText.text = "0.0m";
        }
        
	}

    // Return the acceleration value
    public float getAcceleration()
    {
        return acceleration;
    }
}
