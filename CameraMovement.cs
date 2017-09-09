using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMovement : MonoBehaviour {

    public GameObject ball;
	
	// Update is called once per frame
    // Giving the ball the same force as the ball
	void Update () {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, ball.GetComponent<BallAcceleration>().getAcceleration()));
	}
}
